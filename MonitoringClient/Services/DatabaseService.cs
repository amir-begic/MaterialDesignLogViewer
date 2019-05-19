using System;
using System.Windows;
using MonitoringClient.Exceptions;
using MySql.Data.MySqlClient;

namespace MonitoringClient.Services
{
    public class DatabaseService : IDatabaseService
    {
        private string _connectionString;

        public DatabaseService()
        {
            _connectionString = BuildConnString();
        }

        public bool CloseDatabaseConnection()
        {
            throw new NotImplementedException();
        }

        public MySqlConnection CreateDatabaseConnection()
        {
            _connectionString = BuildConnString();
            return new MySqlConnection(_connectionString);
        }

        public MySqlCommand CreateCommand(string commandText, MySqlConnection connection)
        {
            return new MySqlCommand(commandText, connection);
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

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                try
                {
                    connection.Open();

                    MessageBox.Show("Connection successful");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private string BuildConnString()
        {
            return string.Format("Server={0};Database={1};Uid={2};Pwd={3};",
            Properties.Settings.Default.Hostname, 
            Properties.Settings.Default.Database, 
            Properties.Settings.Default.Username, 
            Properties.Settings.Default.Password);
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
