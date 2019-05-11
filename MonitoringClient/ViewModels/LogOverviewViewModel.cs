using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitoringClient.Models;

namespace MonitoringClient.ViewModels
{
    public class LogOverviewViewModel
    {
        public LogOverviewViewModel()
        {
            LogEntries = new[]
            {
                new LogEntry
                {
                    Hostname = "Host1",
                    Id = 123123,
                    Location = "De",
                    Message = "Test",
                    Pod = "137ddd",
                    Severity = 3,
                    Timestamp = DateTime.Today
                },
                new LogEntry
                {
                    Hostname = "Host2",
                    Id = 12341241,
                    Location = "Fr",
                    Message = "Test2",
                    Pod = "137ffd",
                    Severity = 4,
                    Timestamp = new DateTime(2017,12,26,8,38,12)
                }
            };
        }

        public LogEntry[] LogEntries { get; set; }
    }
}
