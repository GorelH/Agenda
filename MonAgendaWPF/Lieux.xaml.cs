using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MonAgendaWPF
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Lieux : Window
    {
        public Lieux()
        {
            InitializeComponent();
            this.Activated += new EventHandler(Lieux_Activated);
        }

        void Lieux_Activated(object sender, EventArgs e)
        {
            foreach (string ar in MainWindow.Instance.BM.AfficherLieuEvenementsProgrammes())
            {
                addLieu(ar);
            }
        }

        private void addLieu(string ar)
        {
            if (ar == null)
                throw new ArgumentNullException();

            TextBlock t = new TextBlock();
            t.Text = ar;
            lieux.Children.Add(t);
        }
    }
}
