using System.ComponentModel;
using System.Linq;
using MonAgendaWPF.Utils;

namespace MonAgendaWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour Events.xaml
    /// </summary>
    public partial class Events : AbstractWindow
    {
        public Events()
        {
            InitializeComponent();

            EventsList.ItemsSource = App.BusinessManager.EvenementsClassesDate().ToList();
        }

        private new void Window_Closing(object sender, CancelEventArgs e)
        {
            base.Window_Closing(sender, e);
        }
    }
}
