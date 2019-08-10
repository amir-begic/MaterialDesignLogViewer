using System;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MonitoringClient.Models;
using MonitoringClient.Services.RepositoryServices;

namespace MonitoringClient.ViewModels
{
    public interface IAddCustomerDialogViewModel { }
    public class AddCustomerDialogViewModel : IAddCustomerDialogViewModel
    {
        private ICommand _addCustomerCommand;
        private readonly IRepositoryBase<CustomerModel> _customerRepository;

        public AddCustomerDialogViewModel(IRepositoryBase<CustomerModel> customerRepository)
        {
            _customerRepository = customerRepository;
            NewCustomerModel = new CustomerModel
            {
                Address = 1,
                Person = 1
                
            };
        }

        private void AddCustomer()
        {
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