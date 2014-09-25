using System;
using System.Windows;
using System.Windows.Input;
using BusinessLayer;

namespace MonAgendaWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login
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
            if (App.BusinessManager.CheckUserConnection(loginTextBox.Text, SHA1Helper.HashData(passwordBox.Password)))
            {
                App._currentUser = loginTextBox.Text;
                var mainWindow = new MainWindow();
                mainWindow.Show();
                errorLabel.Visibility = Visibility.Hidden;
                Close();
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
