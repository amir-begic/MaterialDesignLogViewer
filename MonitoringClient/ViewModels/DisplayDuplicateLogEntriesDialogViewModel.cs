using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuplicateCheckerLib;
using MonitoringClient.Models;
using MonitoringClient.Services;

namespace MonitoringClient.ViewModels
{
    public interface IDisplayDuplicateLogEntriesDialogViewModel
    {

    }
    public class DisplayDuplicateLogEntriesDialogViewModel : IDisplayDuplicateLogEntriesDialogViewModel
    {
        private readonly ILogEntriesService _logEntriesService;
        public DisplayDuplicateLogEntriesDialogViewModel(ILogEntriesService logEntriesService)
        {
            _logEntriesService = logEntriesService;
            LogEntries = new ObservableCollection<IEntity>();
            GetDuplicateLogEntries();
        }

        private void GetDuplicateLogEntries()
        {

            var logentries = _logEntriesService.GetDuplicateLogEntries();
            foreach (var logentry in logentries)
            {
                if (logentry!=null)
                LogEntries.Add(logentry);
            }
        }

        public ObservableCollection<IEntity> LogEntries { get; set; }
    }
}
