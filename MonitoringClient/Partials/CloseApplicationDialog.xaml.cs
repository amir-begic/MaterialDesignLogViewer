using System.Windows;
using System.Windows.Controls;

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
            Application.Current.Shutdown();
        }
    }
}
