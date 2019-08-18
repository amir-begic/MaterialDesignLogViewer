using LinqToDB.Data;
using MonitoringClient.Models;

namespace MonitoringClient.Services.RepositoryServices
{
    public class LoggingRepository : RepositoryBase<LogEntryModel>
    {
        public override string TableName => "v_logentries";

        public LoggingRepository(IDatabaseService<LogEntryModel> databaseService) : base(databaseService)
        {
        }

        public override void ClearByProcedure<P>(P kValue)
        {

            var dParams = new DataParameter[]
            {
                new DataParameter("id", kValue),
            };

            _databaseService.RunStoredProcedure<LogEntryModel>("LogClear", dParams);
        }

        public override void AddByProcedure(LogEntryModel logEntryModel)
        {
            var dParams = new DataParameter[]
            {
                new DataParameter("pod", logEntryModel.Pod ?? ""),
                new DataParameter("hostname", logEntryModel.Hostname ?? ""),
                new DataParameter("severity", logEntryModel.Severity),
                new DataParameter("message", logEntryModel.Message ?? ""),
                new DataParameter("location", logEntryModel.Location ?? "")
            };
            _databaseService.RunStoredProcedure<LogEntryModel>("LogMessageAdd", dParams);
        }
    }
}
