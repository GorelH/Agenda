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
    /// Logique d'interaction pour Artistes.xaml
    /// </summary>
    public partial class Artistes : Window
    {
        public Artistes()
        {
            InitializeComponent();
            this.Activated += new EventHandler(Artistes_Activated);
        }

        void Artistes_Activated(object sender, EventArgs e)
        {
            foreach (string ar in MainWindow.Instance.BM.AfficherArtistes())
            {
                addArtiste(ar);
            }
        }

        private void addArtiste(string ar)
        {
            if (ar == null)
                throw new ArgumentNullException();

            TextBlock t = new TextBlock();
            t.Text = ar;
            artistes.Children.Add(t);
        }
    }
}
