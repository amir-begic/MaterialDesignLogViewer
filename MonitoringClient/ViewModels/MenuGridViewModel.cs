using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MonitoringClient.Models.UI;
using MonitoringClient.Partials;

namespace MonitoringClient.ViewModels
{
    public interface IMenuGridViewModel
    {

    }
    public class MenuGridViewModel : IMenuGridViewModel
    {
        public MenuGridViewModel(IServiceProvider serviceProvider)
        {
            MenuItems = new[]
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
