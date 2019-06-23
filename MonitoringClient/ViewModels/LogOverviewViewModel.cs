using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using MonitoringClient.Models;
using MonitoringClient.Partials;
using MonitoringClient.Services;
using MonitoringClient.Services.RepositoryServices;

namespace MonitoringClient.ViewModels
{
    public interface ILogOverviewViewModel
    {

    }
    public class LogOverviewViewModel : ILogOverviewViewModel
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRepositoryBase<LogEntry> _loggingRepository;
        private ICommand _refreshLogentriesCommand;
        private ICommand _clearLogEntryCommand;
        private ICommand _addLogEntryCommand;
        private ICommand _showDuplicateEntriesCommand;

        public LogOverviewViewModel(IServiceProvider serviceProvider, IRepositoryBase<LogEntry> loggingRepository)
        {
            _loggingRepository = loggingRepository;
            _serviceProvider = serviceProvider;

            LogEntries = new ObservableCollection<LogEntry>
            {
                new LogEntry
                {
                    Hostname = "Host1",
                    Id = 123123,
                    Location = "De",
                    Message = "Bitte Connection String in den Settings im Burgermenü hinzufügen",
                    Pod = "137ddd",
                    Severity = 4,
                    Timestamp = DateTime.Today
                },
                new LogEntry
                {
                    Hostname = "Host2",
                    Id = 12341241,
                    Location = "Fr",
                    Message = "Bitte Connection String in den Settings im Burgermenü hinzufügen",
                    Pod = "137ffd",
                    Severity = 4,
                    Timestamp = new DateTime(2017,12,26,8,38,12)
                }
            };
            
            SelectedLogEntry = LogEntries.First();
        }

        private void ClearLogEntry()
        {
            if (SelectedLogEntry == null)
                return;

            _loggingRepository.ClearByProcedure(SelectedLogEntry.Id);
            RefreshLogEntries();
        }

        private void RefreshLogEntries()
        {
            LogEntries.Clear();
            foreach (var logEntry in _loggingRepository.GetAll())
            {
                LogEntries.Add(logEntry);
            }
            
        }

        private async void AddLogEntry()
        {

            var dialog = new AddLogEntryDialog
            {
                DataContext = _serviceProvider.GetRequiredService<IAddLogEntryDialogViewModel>()
            };

            var result = await DialogHost.Show(dialog);
            if (!Equals(result, "0"))
            {
                RefreshLogEntries();
            }
        }

        private async void ShowDuplicateEntries()
        {
            var dialog = new DisplayDuplicateLogEntriesDialog
            {
                DataContext = _serviceProvider.GetRequiredService<IDisplayDuplicateLogEntriesDialogViewModel>()
            };

             var result = await DialogHost.Show(dialog);
        }

        public ICommand RefreshLogEntriesCommand
        {
            get
            {
                if (_clearLogEntryCommand == null)
                {
                    _clearLogEntryCommand = new RelayCommand(
                        p =>true,
                        p=> RefreshLogEntries());
                }

                return _clearLogEntryCommand;
            }
        }

        public ICommand GetDuplicateEntriesCommand
        {
            get
            {
                if (_showDuplicateEntriesCommand == null)
                {
                    _showDuplicateEntriesCommand = new RelayCommand(
                        p => true,
                        p => ShowDuplicateEntries());
                }

                return _showDuplicateEntriesCommand;
            }
        }

        public ICommand ClearLogEntryCommand
        {
            get
            {
                if (_refreshLogentriesCommand == null)
                {
                    _refreshLogentriesCommand = new RelayCommand(
                        p => true,
                        p => ClearLogEntry());
                }

                return _refreshLogentriesCommand;
            }
        }
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
        public ObservableCollection<LogEntry> LogEntries { get; set; }
        public LogEntry SelectedLogEntry { get; set; }
    }
}
