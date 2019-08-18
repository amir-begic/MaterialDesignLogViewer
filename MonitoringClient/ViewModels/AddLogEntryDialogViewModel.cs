using System;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MonitoringClient.Models;
using MonitoringClient.Services;
using MonitoringClient.Services.RepositoryServices;

namespace MonitoringClient.ViewModels
{
    public interface IAddLogEntryDialogViewModel
    {

    }
    public class AddLogEntryDialogViewModel : IAddLogEntryDialogViewModel
    {

        private ICommand _addLogEntryCommand;
        private readonly IRepositoryBase<LogEntryModel> _loggingRepository;

        public AddLogEntryDialogViewModel(IRepositoryBase<LogEntryModel> loggingRepository)
        {
            _loggingRepository = loggingRepository;
            NewLogEntryModel = new LogEntryModel
            {
                Timestamp = DateTime.Now
            };
        }

        private void AddLogEntry()
        {
            _loggingRepository.AddByProcedure(NewLogEntryModel);
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        public LogEntryModel NewLogEntryModel { get; set; }

        public ICommand AddLogEntryCommand
        {
            get
            {
                if (_addLogEntryCommand == null)
                {
                    _addLogEntryCommand = new RelayCommand(
                        p => true,
                        p => AddLogEntry());
                }

                return _addLogEntryCommand;
            }
        }
    }
}
