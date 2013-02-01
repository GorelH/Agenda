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
    /// Logique d'interaction pour EvenementsParLieu.xaml
    /// </summary>
    public partial class EvenementsParLieu : Window
    {
        public EvenementsParLieu()
        {
            InitializeComponent();
            this.Activated += new EventHandler(remplirLieu);
            lieuChoisi.SelectionChanged += new SelectionChangedEventHandler(EvenementsParLieu_Activated);
        }

        void remplirLieu(object sender, EventArgs e)
        {
            foreach (string ar in MainWindow.Instance.BM.AfficherLieuEvenementsProgrammes())
            {
                lieuChoisi.Items.Add(ar);
            }

            if (lieuChoisi.Items.Count > 0)
            {
                lieuChoisi.SelectedIndex = 0;
            }
        }

        void EvenementsParLieu_Activated(object sender, EventArgs e)
        {
            if (lieuChoisi.Items.Count > 0)
            {
                evenementsParLieu.Children.Clear();
                foreach (string ar in MainWindow.Instance.BM.AfficherEvenementsLieux(MainWindow.Instance.BM.GetLieuParNom(lieuChoisi.SelectedItem.ToString())))
                {
                    addEvenementsParLieu(ar);
                }
            }
        }

        private void addEvenementsParLieu(string ar)
        {
            if (ar == null)
                throw new ArgumentNullException();

            TextBlock t = new TextBlock();
            t.Text = ar;
            evenementsParLieu.Children.Add(t);
        }
    }
}
