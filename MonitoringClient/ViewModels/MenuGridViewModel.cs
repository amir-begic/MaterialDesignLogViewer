using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MonitoringClient.Models;
using MonitoringClient.Models.UI;
using MonitoringClient.Partials;
using MonitoringClient.Services;
using MonitoringClient.Services.RepositoryServices;

namespace MonitoringClient.ViewModels
{
    public interface IMenuGridViewModel
    {

    }
    public class MenuGridViewModel : IMenuGridViewModel
    {
        public static IServiceProvider Container { get; private set; }
        public MenuGridViewModel()
        {
            //Initial Container and Service registration
            var services = new ServiceCollection();
            services.AddTransient<IDatabaseService<LogEntry>, DatabaseService<LogEntry>>();
            //services.AddSingleton<IDatabaseService<LocationModel>, DatabaseService<LocationModel>>();
            //services.AddSingleton<ILogEntriesService, LogEntriesService>();
            services.AddTransient<IRepositoryBase<LogEntry>, LoggingRepository>();
            //services.AddTransient<IRepositoryBase<LocationModel>, LocationRepository>();

            services.AddTransient<IMainWindowViewModel, MainWindowViewModel>();
            services.AddTransient<ISettingsViewModel, SettingsViewModel>();
            services.AddTransient<ILogOverviewViewModel, LogOverviewViewModel>();
            services.AddTransient<IAddLogEntryDialogViewModel, AddLogEntryDialogViewModel>();
            services.AddTransient<IDisplayDuplicateLogEntriesDialogViewModel, DisplayDuplicateLogEntriesDialogViewModel>();
            services.AddTransient<IMenuGridViewModel, MenuGridViewModel>();
            Container = services.BuildServiceProvider();


            MenuItems = new[]
            {
                new MenuItem("Log Overview", new LogOverview
                {
                    DataContext = Container.GetRequiredService<ILogOverviewViewModel>()
                }),
                new MenuItem("Settings", new Settings
                {
                    DataContext = Container.GetRequiredService<ISettingsViewModel>()
                })
            };
        }
        
        public MenuItem[] MenuItems { get; set; }
    }

}
