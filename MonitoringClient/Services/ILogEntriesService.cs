using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DuplicateCheckerLib;
using MonitoringClient.Models;

namespace MonitoringClient.Services
{
    public interface ILogEntriesService
    {
        ObservableCollection<LogEntry> GetLogEntries();
        void LogMessageAdd(LogEntry logEntry);
        void ClearLogEntry(int id);
        ObservableCollection<LogEntry> GetDuplicateLogEntries();
    }
}