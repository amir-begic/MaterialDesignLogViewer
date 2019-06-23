using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DuplicateCheckerLib;
using MonitoringClient.Models;

namespace MonitoringClient.Services.RepositoryServices
{
    public class LoggingRepository : RepositoryBase<LogEntry>
    {
        private readonly DuplicateChecker _duplicateChecker;
        public override string TableName => "v_logentries";

        public LoggingRepository(IDatabaseService databaseService) : base(databaseService)
        {
           _duplicateChecker = new DuplicateChecker();
        }

        public override void ClearByProcedure<P>(P kValue)
        {
            try
            {
                using (var conn = _databaseService.CreateDatabaseConnection())
                {
                    using (var cmd = _databaseService.CreateCommand("LogClear", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id", kValue);
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


        public override LogEntry GetSingle<P>(P pk)
        {
            var logEntry = new LogEntry();
            var parameterDictionary = new Dictionary<string, object>
            {
                { "id", pk }
            };
            var commandText = "SELECT * FROM " + TableName + CreateWhereCondition("idLogging = @id", parameterDictionary);
            try
            {
                using (var conn = _databaseService.CreateDatabaseConnection())
                {
                    using (var cmd = _databaseService.CreateCommand(commandText, conn))
                    {
                        conn.Open();
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            logEntry = new LogEntry
                            {
                                Id = (int?) reader[0] ?? 999,
                                Pod = reader[1] != null ? (string) reader[1] : "ERROR NULL",
                                Location = reader[2] != null ? (string) reader[2] : "ERROR NULL",
                                Hostname = reader[3] != null ? (string) reader[3] : "ERROR NULL",
                                Severity = (int?) reader[4] ?? 999,
                                Timestamp = (DateTime) reader[5],
                                Message = reader[6] != null ? (string) reader[6] : "Error NULL"
                            };
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return logEntry;
        }
        
        public override List<LogEntry> GetDuplicateLogEntries()
        {
            var logEntries = GetAll();
            var duplicateLogEntries = new List<LogEntry>();

            var dups = _duplicateChecker.FindDuplicates(logEntries).Where(x => x is LogEntry).Cast<LogEntry>();
            foreach (var t in dups)
            {
                duplicateLogEntries.Add(t);
            }

            return duplicateLogEntries;
        }

        public override void AddByProcedure(LogEntry logEntry)
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


        public override List<LogEntry> GetAll()
        {
            var logEntries = new List<LogEntry>();
            var commandText = "SELECT * FROM " + TableName;
            try
            {
                using (var conn = _databaseService.CreateDatabaseConnection())
                {
                    using (var cmd = _databaseService.CreateCommand(commandText, conn))
                    {
                        conn.Open();
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            logEntries.Add(new LogEntry
                            {
                                Id = (int?)reader[0] ?? 999,
                                Pod = reader[1] != null ? (string)reader[1] : "ERROR NULL",
                                Location = reader[2] != null ? (string)reader[2] : "ERROR NULL",
                                Hostname = reader[3] != null ? (string)reader[3] : "ERROR NULL",
                                Severity = (int?)reader[4] ?? 999,
                                Timestamp = (DateTime)reader[5],
                                Message = reader[6] != null ? (string)reader[6] : "Error NULL"
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return logEntries;
        }

        public override List<LogEntry> GetAll(string whereCondition, Dictionary<string, object> parameterValues)
        {
            var logEntries = new List<LogEntry>();
            var commandText = "SELECT * FROM " + TableName + CreateWhereCondition(whereCondition, parameterValues);
            try
            {
                using (var conn = _databaseService.CreateDatabaseConnection())
                {
                    using (var cmd = _databaseService.CreateCommand(commandText, conn))
                    {
                        conn.Open();
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            logEntries.Add(new LogEntry
                            {
                                Id = (int?)reader[0] ?? 999,
                                Pod = reader[1] != null ? (string)reader[1] : "ERROR NULL",
                                Location = reader[2] != null ? (string)reader[2] : "ERROR NULL",
                                Hostname = reader[3] != null ? (string)reader[3] : "ERROR NULL",
                                Severity = (int?)reader[4] ?? 999,
                                Timestamp = (DateTime)reader[5],
                                Message = reader[6] != null ? (string)reader[6] : "Error NULL"
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return logEntries;
        }
    }
}
