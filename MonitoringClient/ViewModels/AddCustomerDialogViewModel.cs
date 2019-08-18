using System;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MonitoringClient.Models;
using MonitoringClient.Models.EntityFramework;
using MonitoringClient.Services.EncryptionService;
using MonitoringClient.Services.RepositoryServices;
using MonitoringClient.Services.RepositoryServices.MsSqlRepository;

namespace MonitoringClient.ViewModels
{
    public interface IAddCustomerDialogViewModel { }
    public class AddCustomerDialogViewModel : IAddCustomerDialogViewModel
    {
        private ICommand _addCustomerCommand;
        private readonly IRepositoryBaseMsSql<Customer> _customerRepository;
        private readonly IEncryptionService _encryptionService;

        public AddCustomerDialogViewModel(IRepositoryBaseMsSql<Customer> customerRepository,
            IEncryptionService encryptionService)
        {
            _customerRepository = customerRepository;
            _encryptionService = encryptionService;
            NewCustomerModel = new Customer();
        }

        private void AddCustomer()
        {
            NewCustomerModel.Password = _encryptionService.GenerateSaltedHash(NewCustomerModel.Password);
            _customerRepository.Add(NewCustomerModel);
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        public Customer NewCustomerModel { get; set; }

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
    }
}