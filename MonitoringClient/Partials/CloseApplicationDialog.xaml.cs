using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonitoringClient.Partials
{
    /// <summary>
    /// Interaction logic for CloseApplicationDialog.xaml
    /// </summary>
    public partial class CloseApplicationDialog : UserControl
    {
        public CloseApplicationDialog()
        {
            InitializeComponent();
        }

        private async void CloseApplicationButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Todo: Implement Aplication close and event which closes the Database Connection.
        }
    }
}
