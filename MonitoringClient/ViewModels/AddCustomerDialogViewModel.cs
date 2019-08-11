using System;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MonitoringClient.Models;
using MonitoringClient.Services.EncryptionService;
using MonitoringClient.Services.RepositoryServices;

namespace MonitoringClient.ViewModels
{
    public interface IAddCustomerDialogViewModel { }
    public class AddCustomerDialogViewModel : IAddCustomerDialogViewModel
    {
        private ICommand _addCustomerCommand;
        private readonly IRepositoryBase<CustomerModel> _customerRepository;
        private readonly IEncryptionService _encryptionService;

        public AddCustomerDialogViewModel(IRepositoryBase<CustomerModel> customerRepository,
            IEncryptionService encryptionService)
        {
            _customerRepository = customerRepository;
            _encryptionService = encryptionService;
            NewCustomerModel = new CustomerModel
            {
                Address = 1,
                Person = 1
                
            };
        }

        private void AddCustomer()
        {
            NewCustomerModel.Password = _encryptionService.GenerateSaltedHash(NewCustomerModel.Password);
            _customerRepository.Add(NewCustomerModel);
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        public CustomerModel NewCustomerModel { get; set; }

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