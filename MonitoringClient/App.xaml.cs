using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MonitoringClient.Services;
using MonitoringClient.ViewModels;

namespace MonitoringClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider Container { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            services.AddSingleton<IDatabaseService, DatabaseService>();
            services.AddSingleton<ILogEntriesService, LogEntriesService>();
            services.AddTransient<IMainWindowViewModel, MainWindowViewModel>();
            services.AddTransient<ISettingsViewModel, SettingsViewModel>();
            services.AddTransient<ILogOverviewViewModel, LogOverviewViewModel>();
            services.AddTransient<IAddLogEntryDialogViewModel, AddLogEntryDialogViewModel>();
            Container = services.BuildServiceProvider();

            var window = new MainWindow
            {
                DataContext = Container.GetRequiredService<IMainWindowViewModel>()
            };
            window.Show();
        }

    }
}
