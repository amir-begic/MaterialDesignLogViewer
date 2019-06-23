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
        private readonly IRepositoryBase<LogEntry> _loggingRepository;

        public AddLogEntryDialogViewModel(IRepositoryBase<LogEntry> loggingRepository)
        {
            _loggingRepository = loggingRepository;
            NewLogEntry = new LogEntry
            {
                Timestamp = DateTime.Now
            };
        }

        private void AddLogEntry()
        {
            _loggingRepository.AddByProcedure(NewLogEntry);
            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        public LogEntry NewLogEntry { get; set; }

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
