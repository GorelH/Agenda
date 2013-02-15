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
using MonAgendaWPF.ViewModel;

namespace MonAgendaWPF
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
            EventManagementViewModel model = new EventManagementViewModel(App.BusinessManager.EvenementsClassesDate());

            DataContext = model;
        }
    }
}
