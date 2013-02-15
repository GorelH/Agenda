using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using BusinessLayer;

namespace MonAgendaWPF
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// L'utilisateur courant.
        /// </summary>
        static public string _currentUser;

        /// <summary>
        /// Le business de l'application
        /// </summary>
        static private BusinessManager _businessManager = new BusinessManager();

        public static BusinessManager BusinessManager
        {
            get { return App._businessManager; }
            set { App._businessManager = value; }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
            e.Handled = true;
        }
    }
}
