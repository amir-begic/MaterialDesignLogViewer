using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MonitoringClient.Models;

namespace MonitoringClient.Services
{
    public class LogEntriesService : ILogEntriesService
    {
        private readonly IDatabaseService _databaseService;

        public LogEntriesService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public void ClearLogEntry(int id)
        {
            try
            {
                using (var conn = _databaseService.CreateDatabaseConnection())
                {
                    using (var cmd = _databaseService.CreateCommand("LogClear", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id", id);
                        conn.Open();
                        var result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
        }

        public ObservableCollection<LogEntry> GetLogEntries()
        {
            var logEntries = new ObservableCollection<LogEntry>();
            try
            {
                using (var conn = _databaseService.CreateDatabaseConnection())
                {
                    using (var cmd = _databaseService.CreateCommand("SELECT * FROM v_logentries",conn))
                    {
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        
                        while (reader.Read())
                        {
                            logEntries.Add(new LogEntry
                            {
                                Id = (int?) reader[0] ?? 999,
                                Pod = reader[1] != null ? (string)reader[1] : "ERROR NULL",
                                Location = reader[2] != null ? (string)reader[2] : "ERROR NULL",
                                Hostname = reader[3] != null ? (string)reader[3] : "ERROR NULL",
                                Severity = (int?)reader[4] ?? 999,
                                Timestamp = (DateTime)reader[5],
                                Message = reader[6] != null ? (string)reader[6]:"Error NULL"
                            });
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return logEntries;
        }

        public void LogMessageAdd(LogEntry logEntry)
        {
            try
            {
                using (var conn = _databaseService.CreateDatabaseConnection())
                {
                    using (var cmd = _databaseService.CreateCommand("LogMessageAdd", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("pod", logEntry.Pod ?? "");
                        cmd.Parameters.AddWithValue("hostname", logEntry.Hostname ?? "");
                        cmd.Parameters.AddWithValue("severity", logEntry.Severity);
                        cmd.Parameters.AddWithValue("message", logEntry.Message ?? "");
                        cmd.Parameters.AddWithValue("location", logEntry.Location ?? "");
                        conn.Open();
                        var result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
        }
    }
}
