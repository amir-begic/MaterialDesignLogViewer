using MySql.Data.MySqlClient;

namespace MonitoringClient.Services
{
    public interface IDatabaseService
    {
        MySqlConnection CreateDatabaseConnection();
        MySqlCommand CreateCommand(string commandText, MySqlConnection connection);
        bool CloseDatabaseConnection();
        void TestDatabaseConnection();
    }
}
