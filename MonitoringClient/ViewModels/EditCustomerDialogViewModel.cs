using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MonitoringClient.Models;
using MonitoringClient.Services.EncryptionService;
using MonitoringClient.Services.RepositoryServices;

namespace MonitoringClient.ViewModels
{
    public interface IEditCustomerDialogViewModel {}

    public class EditCustomerDialogViewModel : IEditCustomerDialogViewModel
    {
        private ICommand _updateCustomerCommand; 

        private readonly IRepositoryBase<CustomerModel> _customerRepository;
        private readonly IEncryptionService _encryptionService;

        public EditCustomerDialogViewModel(IRepositoryBase<CustomerModel> customerRepository, CustomerModel selectedCustomerModel,
            IEncryptionService encryptionService)
        {
            _customerRepository = customerRepository;
            _encryptionService = encryptionService;
            SelectedCustomer = selectedCustomerModel;
        }

        public CustomerModel SelectedCustomer { get; set; }

        private void UpdateCustomer()
        {
            SelectedCustomer.Password = _encryptionService.GenerateSaltedHash(SelectedCustomer.Password);
            _customerRepository.Update(SelectedCustomer);
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        public ICommand UpdateCustomerCommand
        {
            get
            {
                if (_updateCustomerCommand == null)
                {
                    _updateCustomerCommand = new RelayCommand(
                        p => true,
                        p => UpdateCustomer());
                }

                return _updateCustomerCommand;
            }
        }

    }
}
