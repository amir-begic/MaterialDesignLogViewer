using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MonitoringClient.Models;
using MonitoringClient.Models.EntityFramework;
using MonitoringClient.Services.EncryptionService;
using MonitoringClient.Services.RepositoryServices;
using MonitoringClient.Services.RepositoryServices.MsSqlRepository;

namespace MonitoringClient.ViewModels
{
    public interface IEditCustomerDialogViewModel {}

    public class EditCustomerDialogViewModel : IEditCustomerDialogViewModel
    {
        private ICommand _updateCustomerCommand; 

        private readonly IRepositoryBaseMsSql<Customer> _customerRepository;
        private readonly IEncryptionService _encryptionService;

        public EditCustomerDialogViewModel(IRepositoryBaseMsSql<Customer> customerRepository, Customer selectedCustomerModel,
            IEncryptionService encryptionService)
        {
            _customerRepository = customerRepository;
            _encryptionService = encryptionService;
            SelectedCustomer = selectedCustomerModel;
        }

        public Customer SelectedCustomer { get; set; }

        private void UpdateCustomer()
        {
            SelectedCustomer.Password = _encryptionService.GenerateSaltedHash(SelectedCustomer.Password);
            _customerRepository.Update(SelectedCustomer.Id, SelectedCustomer);
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
