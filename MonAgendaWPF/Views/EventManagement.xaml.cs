using System.Windows;
using MonAgendaWPF.Utils;
using MonAgendaWPF.ViewModel;

namespace MonAgendaWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour EventManagement.xaml
    /// </summary>
    public partial class EventManagement : AbstractWindow
    {
        public EventManagement()
        {
            InitializeComponent();
        }

        private void AbstractWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var model = new EventManagementViewModel(App.BusinessManager.EvenementsClassesDate());

            DataContext = model;
        }
    }
}
