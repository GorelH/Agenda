using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MonAgendaWPF.Controls
{
    /// <summary>
    /// Logique d'interaction pour PlanningElementView.xaml
    /// </summary>
    public partial class PlanningElementView
    {
        public PlanningElementView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Locations.ItemsSource = App.BusinessManager.LieuxUtilises().ToList();
        }
    }
}
