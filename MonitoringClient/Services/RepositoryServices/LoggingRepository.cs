using LinqToDB.Data;
using MonitoringClient.Models;

namespace MonitoringClient.Services.RepositoryServices
{
    public class LoggingRepository : RepositoryBase<LogEntry>
    {
        public override string TableName => "v_logentries";

        public LoggingRepository(IDatabaseService<LogEntry> databaseService) : base(databaseService)
        {
        }

        public override void ClearByProcedure<P>(P kValue)
        {

            var dParams = new DataParameter[]
            {
                new DataParameter("id", kValue),
            };

            _databaseService.RunStoredProcedure<LogEntry>("LogClear", dParams);
        }

        public override void AddByProcedure(LogEntry logEntry)
        {
            var dParams = new DataParameter[]
            {
                new DataParameter("pod", logEntry.Pod ?? ""),
                new DataParameter("hostname", logEntry.Hostname ?? ""),
                new DataParameter("severity", logEntry.Severity),
                new DataParameter("message", logEntry.Message ?? ""),
                new DataParameter("location", logEntry.Location ?? "")
            };
            _databaseService.RunStoredProcedure<LogEntry>("LogMessageAdd", dParams);
        }
    }
}
