using LinqToDB;
using LinqToDB.Data;

namespace MonitoringClient.Services
{
    public interface IDatabaseService<M>: IDataContext
    {
        void RunStoredProcedure<M>(string storedProcedureName, DataParameter[] parameters);
        void TestDatabaseConnection();
    }
}
