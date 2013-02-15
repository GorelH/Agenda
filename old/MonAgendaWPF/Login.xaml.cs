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
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            motDePasse.KeyDown += new KeyEventHandler(motDePasse_KeyDown);
            login.Focus();
        }

        void motDePasse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                User u = MainWindow.Instance.BM.Connection(login.Text, motDePasse.Password);
                if (u != null)
                {
                    MainWindow.Instance.ConnectUser(u);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mauvais login ou mot de passe.");
                }
            }
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            User u = MainWindow.Instance.BM.Connection(login.Text, motDePasse.Password);
            if (u != null)
            {
                MainWindow.Instance.ConnectUser(u);
                this.Close();
            }
            else
            {
                MessageBox.Show("Mauvais login ou mot de passe.");
            }
        }
    }
}
