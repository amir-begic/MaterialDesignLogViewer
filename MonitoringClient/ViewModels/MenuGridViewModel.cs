using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MonitoringClient.Models;
using MonitoringClient.Models.EntityFramework;
using MonitoringClient.Models.UI;
using MonitoringClient.Partials;
using MonitoringClient.Services;
using MonitoringClient.Services.EncryptionService;
using MonitoringClient.Services.RepositoryServices;
using MonitoringClient.Services.RepositoryServices.MsSqlRepository;
using MonitoringClient.Services.RepositoryServices.MSSQLRepository;

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
            services.AddScoped<IDatabaseService<LogEntryModel>, DatabaseService<LogEntryModel>>();
            services.AddScoped<IDatabaseService<CustomerModel>, DatabaseService<CustomerModel>>();
            services.AddScoped<IEntityFirstDatabaseService<Customer>, EntityFirstDatabaseService<Customer>>();
            //services.AddSingleton<IDatabaseService<LocationModel>, DatabaseService<LocationModel>>();
            services.AddTransient<IRepositoryBase<LogEntryModel>, LoggingRepository>();
            services.AddTransient<IRepositoryBase<CustomerModel>, CustomerRepository>();
            services.AddTransient<IRepositoryBaseMsSql<Customer>, CustomerRepositoryMsSql>();
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
