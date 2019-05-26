using System;
using System.Windows;
using MonitoringClient.Services;
using MonitoringClient.ViewModels;

namespace MonitoringClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            var window = new MainWindow(
            );
            window.Show();
        }

    }
}
