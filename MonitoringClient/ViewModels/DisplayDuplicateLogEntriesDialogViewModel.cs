using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuplicateCheckerLib;
using MonitoringClient.Models;
using MonitoringClient.Services;
using MonitoringClient.Services.RepositoryServices;

namespace MonitoringClient.ViewModels
{
    public interface IDisplayDuplicateLogEntriesDialogViewModel
    {

    }
    public class DisplayDuplicateLogEntriesDialogViewModel : IDisplayDuplicateLogEntriesDialogViewModel
    {
        private readonly IRepositoryBase<LogEntry> _loggingRepository;
        public DisplayDuplicateLogEntriesDialogViewModel(IRepositoryBase<LogEntry> loggingRepository)
        {
            _loggingRepository = loggingRepository;
            LogEntries = new ObservableCollection<IEntity>();
            GetDuplicateLogEntries();
        }

        private void GetDuplicateLogEntries()
        {

            var logentries = _loggingRepository.GetDuplicateLogEntries();
            foreach (var logentry in logentries)
            {
                if (logentry!=null)
                LogEntries.Add(logentry);
            }
        }

        public ObservableCollection<IEntity> LogEntries { get; set; }
    }
}
