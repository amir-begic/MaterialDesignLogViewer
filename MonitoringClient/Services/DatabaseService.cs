using System;
using System.Configuration;
using System.Windows;
using LinqToDB;
using LinqToDB.Data;
using MonitoringClient.Exceptions;
using MonitoringClient.Models;

namespace MonitoringClient.Services
{
    public class DatabaseService<M> : LinqToDB.Data.DataConnection, IDatabaseService<M> where M : BaseModel, new()

    {
    private string _connectionString;

    public DatabaseService() : base("MonitoringClient")
    {
        _connectionString = BuildConnString();
    }

    public ITable<LogEntryModel> LogEntry => GetTable<LogEntryModel>();
    public ITable<LocationModel> Location => GetTable<LocationModel>();

    public void RunStoredProcedure<M>(string storedProcedureName, DataParameter[] parameters)
    {
        using (var conn = new DataConnection("MySql", _connectionString))
        {
            conn.QueryProc<M>(storedProcedureName, parameters);
        }
    }

    public void TestDatabaseConnection()
    {
        try
        {
            ValidateSettings();
        }
        catch (MissingSettingException missingSettingException)
        {
            MessageBox.Show(missingSettingException.Message, "Connection Failed!", MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        var connString = BuildConnString();

        using (var conn = new DataConnection("MySql", connString))
        {
            try
            {
                conn.Connection.Open();

                MessageBox.Show("Connection successful");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    private string BuildConnString()
    {
        var connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3};",
            Properties.Settings.Default.Hostname,
            Properties.Settings.Default.Database,
            Properties.Settings.Default.Username,
            Properties.Settings.Default.Password);

        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        var connectionStringsSection = (ConnectionStringsSection) config.GetSection("connectionStrings");
        connectionStringsSection.ConnectionStrings["MonitoringClient"].ConnectionString = connectionString;
        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("connectionStrings");
        
        return connectionString;
    }

    private void ValidateSettings()
    {
        if (Properties.Settings.Default.Hostname.Length == 0 ||
            Properties.Settings.Default.Username.Length == 0 ||
            Properties.Settings.Default.Password.Length == 0 ||
            Properties.Settings.Default.Hostname.Length == 0)
        {
            throw new MissingSettingException("Not all Settings are correctly set.");
        }
    }
    }
}
