using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Xsl;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using MonitoringClient.Models;
using MonitoringClient.Partials;
using MonitoringClient.Services.RepositoryServices;
using MySql.Data.MySqlClient.Authentication;

namespace MonitoringClient.ViewModels
{
    public interface ICustomerOverviewViewModel
    {

    }

    

    public class CustomerOverviewViewModel : ICustomerOverviewViewModel
    {
        private readonly IRepositoryBase<CustomerModel> _customerRepository;
        private readonly IServiceProvider _serviceProvider;
        private ICommand _refreshCustomersCommand;
        private ICommand _addCustomerCommand;
        private ICommand _editCustomerCommand;
        private ICommand _deleteCustomersCommand;

        public CustomerOverviewViewModel(IServiceProvider serviceProvider, IRepositoryBase<CustomerModel> customerRepository)
        {
            _serviceProvider = serviceProvider;

            Customers = new ObservableCollection<CustomerModel>{
                new CustomerModel
                {
                    CustomerNr = "CU00001",
                    Password = "",
                    TelephoneNr = "+41 2202 3003 20",
                    Website = "lo"
                }
            };

            _customerRepository = customerRepository;
        }

        private void RefreshCustomers()
        {
            Customers.Clear();
            foreach (var logEntry in _customerRepository.GetAll())
            {
                Customers.Add(logEntry);
            }
        }

        private void DeleteCustomer()
        {
            if (SelectedCustomer==null)
                return;

            _customerRepository.Delete(SelectedCustomer);
            RefreshCustomers();
        }

        private async void EditCustomer()
        {
            if (SelectedCustomer==null)
                return;

            var dialog = new EditCustomerDialog()
            {
                DataContext = new EditCustomerDialogViewModel(_customerRepository, SelectedCustomer)
            };

            var result = await DialogHost.Show(dialog);
            if (!Equals(result, "0"))
            {
                RefreshCustomers();
            }
        }

        private async void AddCustomer()
        {
            var dialog = new AddCustomerDialog
            {
                DataContext = _serviceProvider.GetRequiredService<IAddCustomerDialogViewModel>()
            };

            var result = await DialogHost.Show(dialog);
            if (!Equals(result, "0"))
            {
                RefreshCustomers();
            }
        }

        public ICommand AddCustomerCommand
        {
            get
            {
                if (_addCustomerCommand == null)
                {
                    _addCustomerCommand = new RelayCommand(
                        p => true,
                        p => AddCustomer());
                }

                return _addCustomerCommand;
            }
        }

        public ICommand EditCustomerCommand
        {
            get
            {
                if (_editCustomerCommand == null)
                {
                    _editCustomerCommand = new RelayCommand(
                        p => true,
                        p => EditCustomer());
                }

                return _editCustomerCommand;
            }
        }

        public ICommand DeleteCustomerCommand
        {
            get
            {
                if (_deleteCustomersCommand == null)
                {
                    _deleteCustomersCommand = new RelayCommand(
                        p => true,
                        p => DeleteCustomer());
                }

                return _deleteCustomersCommand;
            }
        }

        public ICommand RefreshCustomersCommand
        {
            get
            {
                if (_refreshCustomersCommand == null)
                {
                    _refreshCustomersCommand = new RelayCommand(
                        p => true,
                        p => RefreshCustomers());
                }

                return _refreshCustomersCommand;
            }
        }

        public ObservableCollection<CustomerModel> Customers { get; set; }
        public CustomerModel SelectedCustomer { get; set; }
    }
}
