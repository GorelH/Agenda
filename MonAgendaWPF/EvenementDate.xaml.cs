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
using EntitiesLayer;
namespace MonAgendaWPF
{
    /// <summary>
    /// Logique d'interaction pour EvenementDate.xaml
    /// </summary>
    public partial class EvenementDate : Window
    {
        public EvenementDate()
        {
            InitializeComponent();
            this.Activated += new EventHandler(EvenementDate_StateChanged);
        }

        void EvenementDate_StateChanged(object sender, EventArgs e)
        {
            foreach (string ev in MainWindow.Instance.BM.AfficherEvenements())
            {
                addEvenement(ev);
            }
        }

        private void addEvenement(string ev)
        {
            if (ev == null)
                throw new ArgumentNullException();

            TextBlock t = new TextBlock();
            t.Text = ev;
            evenements.Children.Add(t);
        }
    }
}
