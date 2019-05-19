using System.Collections.ObjectModel;
using MonitoringClient.Models;

namespace MonitoringClient.Services
{
    public interface ILogEntriesService
    {
        ObservableCollection<LogEntry> GetLogEntries();
        void LogMessageAdd(LogEntry logEntry);
        void ClearLogEntry(int id);
    }
}