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
    /// Logique d'interaction pour Locations.xaml
    /// </summary>
    public partial class Locations : AbstractWindow
    {
        public Locations()
        {
            InitializeComponent();

            EventsList.ItemsSource = App.BusinessManager.LieuxUtilises().ToList();
        }

        private new void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.Window_Closing(sender, e);
        }
    }
}
