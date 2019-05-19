using System;
using Microsoft.Extensions.DependencyInjection;
using MonitoringClient.Models.UI;
using MonitoringClient.Partials;

namespace MonitoringClient.ViewModels
{
    public interface IMainWindowViewModel
    {
        MenuItem[] MenuItems { get; set; }
    }

    public class MainWindowViewModel : IMainWindowViewModel
    {
        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            MenuItems = new []
            {
                new MenuItem("Log Overview", new LogOverview
                {
                    DataContext = serviceProvider.GetRequiredService<ILogOverviewViewModel>()
                }),
                new MenuItem("Settings", new Settings
                {
                    DataContext = serviceProvider.GetRequiredService<ISettingsViewModel>()
                })
            };
        }

        public MenuItem[] MenuItems { get; set; }
    }
}
