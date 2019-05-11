using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringClient.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public string Pod { get; set; }
        public string Location { get; set; }
        public string Hostname { get; set; }
        public int Severity { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
    }
}
