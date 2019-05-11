using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitoringClient.Models.UI;
using MonitoringClient.Partials;

namespace MonitoringClient.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            MenuItems = new []
            {
                new MenuItem("Log Overview", new LogOverview()),
                new MenuItem("Settings", new Settings())
            };
        }

        public MenuItem[] MenuItems { get; set; }
    }
}
