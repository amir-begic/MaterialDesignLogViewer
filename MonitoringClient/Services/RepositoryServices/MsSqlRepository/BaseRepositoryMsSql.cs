using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Documents;
using MonitoringClient.Services.RepositoryServices.MsSqlRepository;

namespace MonitoringClient.Services.RepositoryServices.MSSQLRepository
{
    public class BaseRepositoryMsSql<M> : IRepositoryBaseMsSql<M> where M : class, new()
    {
        private readonly IEntityFirstDatabaseService<M> _databaseService;

        public BaseRepositoryMsSql(IEntityFirstDatabaseService<M> databaseService)
        {
            _databaseService = databaseService;
        }

        public void Add(M entity)
        {
            try
            {
                if (entity != null)
                {
                    _databaseService.DataSet.Add(entity);
                    _databaseService.Context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
        }
        
        public void Delete(M entity)
        {
            try
            {
                if (entity != null)
                {
                    _databaseService.DataSet.Remove(entity);
                    _databaseService.Context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
        }
        public IQueryable<M> GetAll()
        {
            var entries = Enumerable.Empty<M>().AsQueryable();
            try
            {
                entries = _databaseService.DataSet.Select(x => x);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return entries;
        }

        public void Update(object id, M entity)
        {
             try
            {
                if (id != null && entity != null)
                {
                    var result =_databaseService.DataSet.Find(id);
                    if (result != null)
                    {
                        result = entity;
                        _databaseService.Context.SaveChanges();
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