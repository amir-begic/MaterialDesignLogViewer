using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MonitoringClient.Models;

namespace MonitoringClient.Services.RepositoryServices
{
    public class RepositoryBase<M> : IRepositoryBase<M>
    {

        protected readonly IDatabaseService _databaseService;

        protected RepositoryBase(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public virtual void AddByProcedure(M entity)
        {
            throw new NotImplementedException();
        }

        public virtual void ClearByProcedure<P>(P kValue)
        {
            throw new NotImplementedException();
        }
        public virtual List<M> GetDuplicateLogEntries()
        {
            throw new NotImplementedException();
        }

        public virtual string TableName => "";

        public virtual void Add(M entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual long Count(string whereCondition, Dictionary<string, object> parameterValues)
        {
            var commandText = $"SELECT COUNT(*) FROM {TableName}" + CreateWhereCondition(whereCondition, parameterValues);
            try
            {
                using (var conn = _databaseService.CreateDatabaseConnection())
                {
                    using (var cmd = _databaseService.CreateCommand(commandText, conn))
                    {
                        conn.Open();
                        return (long)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
                throw e;
            }
        }

        public virtual long Count()
        {
            var commandText = $"SELECT COUNT(*) FROM {TableName}";
            try
            {
                using (var conn = _databaseService.CreateDatabaseConnection())
                {
                    using (var cmd = _databaseService.CreateCommand(commandText, conn))
                    {
                        conn.Open();
                        return (long)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
                throw e;
            }
        }

        public virtual void Delete(M entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual List<M> GetAll(string whereCondition, Dictionary<string, object> parameterValues)
        {
            throw new System.NotImplementedException();
        }

        public virtual List<M> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public virtual M GetSingle<P>(P pkValue)
        {
            throw new System.NotImplementedException();
        }

        public virtual System.Linq.IQueryable<M> Query(string whereCondition, Dictionary<string, object> parameterValues)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update(M entity)
        {
            throw new System.NotImplementedException();
        }

        protected string CreateWhereCondition(string whereCondition, Dictionary<string, object> parameterValues)
        {
            var finalWhereCondition = whereCondition;
            if (parameterValues != null && whereCondition != null)
            {
                foreach (var valuePair in parameterValues)
                {
                    finalWhereCondition.Replace("@" + valuePair.Key, valuePair.Value.ToString());
                }

                return " WHERE " + finalWhereCondition;
            }

            return "";
        }
    }
}