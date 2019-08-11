using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Xsl;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using MonitoringClient.Models;
using MonitoringClient.Partials;
using MonitoringClient.Services.EncryptionService;
using MonitoringClient.Services.RepositoryServices;
using MonitoringClient.Validation;
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
        private readonly IEncryptionService _encryptionService;

        private ICommand _refreshCustomersCommand;
        private ICommand _addCustomerCommand;
        private ICommand _editCustomerCommand;
        private ICommand _deleteCustomersCommand;
        private ICommand _telDetailsCommand;

        public CustomerOverviewViewModel(IServiceProvider serviceProvider, IRepositoryBase<CustomerModel> customerRepository,
            IEncryptionService encryptionService)
        {
            _serviceProvider = serviceProvider;
            _encryptionService = encryptionService;
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
                DataContext = new EditCustomerDialogViewModel(_customerRepository, SelectedCustomer, _encryptionService)
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

        private void ShowTelDetails()
        {
            var internationalvorwahl = "";
            var vorwahl = "";
            var nummer = "";
            var durchwahl = "";

            if (SelectedCustomer == null)
                return;
            var validatePhone = new TelephoneNrValidation();

            if (validatePhone.Validate(SelectedCustomer.TelephoneNr, CultureInfo.CurrentCulture).IsValid == false)
                return;

            var match = validatePhone.GetPhoneNrMatchingGroups(SelectedCustomer.TelephoneNr);
            if (match.Groups.Count == 5)
            {
                internationalvorwahl = match.Groups[1].Value;
                vorwahl = match.Groups[2].Value;
                nummer = match.Groups[3].Value;
                durchwahl = match.Groups[4].Value;
            }
            else
            {
                vorwahl = match.Groups[1].Value;
                nummer = match.Groups[2].Value;
                durchwahl = match.Groups[3].Value;
            }

            MessageBox.Show(
                    string.Format("Internationale Vorwahl={0}\n Nationale Vorwahl={1}\n Nummer={2} \nDurchwahl={3};",
                        internationalvorwahl,
                        vorwahl,
                        nummer,
                        durchwahl)
            );
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

        public ICommand TelDetailsCommand
        {
            get
            {
                if (_telDetailsCommand == null)
                {
                    _telDetailsCommand = new RelayCommand(
                        p => true,
                        p => ShowTelDetails());
                }

                return _telDetailsCommand;
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
