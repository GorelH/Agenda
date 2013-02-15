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
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void ConnectionButton_Click(object sender, RoutedEventArgs e)
        {
            connect();
        }

        private void connect()
        {
            MainWindow mainWindow;

            if (App.BusinessManager.CheckUserConnection(loginTextBox.Text, BusinessLayer.SHA1Helper.HashData(passwordBox.Password)))
            {
                App._currentUser = loginTextBox.Text;
                mainWindow = new MainWindow();
                mainWindow.Show();
                errorLabel.Visibility = Visibility.Hidden;
                this.Close();
            }
            else
                errorLabel.Visibility = Visibility.Visible;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                connect();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            loginTextBox.Focus();
        }
    }
}
