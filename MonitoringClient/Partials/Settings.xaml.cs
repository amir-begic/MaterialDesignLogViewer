using System.Windows;
using System.Windows.Controls;
using MonitoringClient.ViewModels;

namespace MonitoringClient.Partials
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings( )
        {
            InitializeComponent();
            
        }

        private void SaveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var ctx = (SettingsViewModel)this.DataContext;
            ctx.TestDatabaseConnection();
        }

        private void ConnStringPasswordBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Password = ConnStringPasswordBox.Password;
        }
    }
}
