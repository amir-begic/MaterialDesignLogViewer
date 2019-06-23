using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MonitoringClient.Models;

namespace MonitoringClient.Services.RepositoryServices
{
    public class LocationRepository : RepositoryBase<LocationModel>
    {
        public LocationRepository(IDatabaseService databaseService) : base(databaseService)
        {
        }
        public override string TableName => "location";

        public override LocationModel GetSingle<P>(P pk)
        {
            var location = new LocationModel();
            var parameterDictionary = new Dictionary<string, object>
            {
                { "id", pk }
            };
            var commandText = "SELECT * FROM " + 
                              TableName + 
                              CreateWhereCondition("idLogging = @id", parameterDictionary);

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
                            location = new LocationModel()
                            {
                                Id = (int?)reader[0] ?? 999,
                                AddressForeignKey = (int?)reader[4] ?? 999,
                                Designation = reader[2] != null ? (string)reader[2] : "ERROR NULL",
                                Building = (int?)reader[4] ?? 999,
                                Room = (int?)reader[4] ?? 999
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

            return location;
        }

        public override void Update(LocationModel location)
        {
            var parameterDictionary = new Dictionary<string, object>
            {
                { "id", location.Id }
            };
            var commandText = $"UPDATE {TableName} " +
                              $"SET address_fk = {location.AddressForeignKey}, " +
                              $"designation = {location.Designation},"+
                              $"building = {location.Building}" +
                              $"room = {location.Room}"+ CreateWhereCondition("id = @id", parameterDictionary);

            try
            {
                using (var conn = _databaseService.CreateDatabaseConnection())
                {
                    using (var cmd = _databaseService.CreateCommand(commandText, conn))
                    {
                        conn.Open();
                        var reader = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
        }

        public override void Delete(LocationModel location)
        {
            var parameterDictionary = new Dictionary<string, object>
            {
                { "id", location.Id }
            };
            var commandText = $"DELETE FROM {TableName} "  
                              + CreateWhereCondition("id = @id", parameterDictionary);
            try
            {
                using (var conn = _databaseService.CreateDatabaseConnection())
                {
                    using (var cmd = _databaseService.CreateCommand(commandText, conn))
                    {
                        conn.Open();
                        var reader = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
        }

        public override void Add(LocationModel location)
        {
            var commandText = $"INSERT INTO {TableName} VALUES (" +
                                 $"{location.AddressForeignKey}," +
                                 $"{location.Designation}," +
                                 $"{location.Building}," +
                                 $"{location.Room})";
            try
            {
                using (var conn = _databaseService.CreateDatabaseConnection())
                {
                    using (var cmd = _databaseService.CreateCommand(commandText, conn))
                    {
                        cmd.CommandType = CommandType.Text;
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

        public override List<LocationModel> GetAll()
        {
            var locations = new List<LocationModel>();
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
                            locations.Add(new LocationModel
                            {
                                Id = (int?)reader[0] ?? 999,
                                AddressForeignKey = (int?)reader[4] ?? 999,
                                Designation = reader[2] != null ? (string)reader[2] : "ERROR NULL",
                                Building = (int?)reader[4] ?? 999,
                                Room = (int?)reader[4] ?? 999
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

            return locations;
        }

        public override List<LocationModel> GetAll(string whereCondition, Dictionary<string, object> parameterValues)
        {
            var locations = new List<LocationModel>();
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
                            locations.Add(new LocationModel
                            {
                                Id = (int?)reader[0] ?? 999,
                                AddressForeignKey = (int?)reader[4] ?? 999,
                                Designation = reader[2] != null ? (string)reader[2] : "ERROR NULL",
                                Building = (int?)reader[4] ?? 999,
                                Room = (int?)reader[4] ?? 999
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

            return locations;
        }
    }
}
