using System.Windows;
using System.Windows.Threading;
using BusinessLayer;

namespace MonAgendaWPF
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App
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
            get { return _businessManager; }
            set { _businessManager = value; }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        static void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
            e.Handled = true;
        }
    }
}
