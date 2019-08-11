using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MonitoringClient.Models;
using MonitoringClient.Models.UI;
using MonitoringClient.Partials;
using MonitoringClient.Services;
using MonitoringClient.Services.EncryptionService;
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
            services.AddScoped<IDatabaseService<LogEntry>, DatabaseService<LogEntry>>();
            services.AddScoped<IDatabaseService<CustomerModel>, DatabaseService<CustomerModel>>();
            //services.AddSingleton<IDatabaseService<LocationModel>, DatabaseService<LocationModel>>();
            //services.AddSingleton<ILogEntriesService, LogEntriesService>();
            services.AddTransient<IRepositoryBase<LogEntry>, LoggingRepository>();
            services.AddTransient<IRepositoryBase<CustomerModel>, CustomerRepository>();
            //services.AddTransient<IRepositoryBase<LocationModel>, LocationRepository>();
            services.AddTransient<IEncryptionService, EncryptionService>();

            services.AddTransient<IMainWindowViewModel, MainWindowViewModel>();
            services.AddTransient<ISettingsViewModel, SettingsViewModel>();
            services.AddTransient<ILogOverviewViewModel, LogOverviewViewModel>();
            services.AddTransient<ICustomerOverviewViewModel, CustomerOverviewViewModel>();
            services.AddTransient<IAddLogEntryDialogViewModel, AddLogEntryDialogViewModel>();
            services.AddTransient<IAddCustomerDialogViewModel, AddCustomerDialogViewModel>();
            services.AddTransient<IDisplayDuplicateLogEntriesDialogViewModel, DisplayDuplicateLogEntriesDialogViewModel>();
            services.AddTransient<IMenuGridViewModel, MenuGridViewModel>();
            Container = services.BuildServiceProvider();


            MenuItems = new[]
            {
                new MenuItem("Log Overview", new LogOverview
                {
                    DataContext = Container.GetRequiredService<ILogOverviewViewModel>()
                }),
                new MenuItem("Customer Overview", new CustomerOverview
                {
                    DataContext = Container.GetRequiredService<ICustomerOverviewViewModel>()
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
