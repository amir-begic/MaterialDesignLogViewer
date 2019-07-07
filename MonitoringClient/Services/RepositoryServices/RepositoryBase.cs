using System;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using DuplicateCheckerLib;
using LinqToDB;
using MonitoringClient.Models;

namespace MonitoringClient.Services.RepositoryServices
{
    public class RepositoryBase<M> : IRepositoryBase<M> where M : BaseModel, new()
    {

        protected readonly IDatabaseService<M> _databaseService;
        protected readonly DuplicateChecker _duplicateChecker;

        protected RepositoryBase(IDatabaseService<M> databaseService)
        {
            _databaseService = databaseService;
            _duplicateChecker = new DuplicateChecker();
        }
        public virtual string TableName => "";
        public virtual void AddByProcedure(M entity)
        {
            throw new NotImplementedException();
        }

        public virtual void ClearByProcedure<P>(P kValue)
        {
            throw new NotImplementedException();
        }
        public virtual IQueryable<M> GetDuplicateLogEntries()
        {
            var allEntries = GetAll();
            var duplicateLogEntries = Enumerable.Empty<M>().AsQueryable();

            var dups = _duplicateChecker.FindDuplicates(allEntries).Where(x => x is M).Cast<M>();
            duplicateLogEntries = dups.AsQueryable();
            return duplicateLogEntries;
        }

        public virtual void Add(M entity)
        {
            try
            {
                if (entity != null)
                {
                    _databaseService.Insert(entity);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
        }
        public virtual void Delete(M entity)
        {
            try
            {
                if (entity != null)
                {
                    _databaseService.Delete(entity);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
        }
        public virtual void Update(M entity)
        {
            try
            {
                if (entity != null)
                {
                    _databaseService.Update(entity);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

        }

        public virtual long Count(Expression<Func<M, bool>> whereCondition)
        {
            return GetAll(whereCondition).Count();
        }

        public virtual long Count()
        {
            return GetAll().Count();
        }

        public virtual IQueryable<M> GetAll(Expression<Func<M, bool>> whereCondition)
        {
            var entries = Enumerable.Empty<M>().AsQueryable();
            try
            {
                entries = _databaseService.GetTable<M>().Where(whereCondition);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return entries;

        }

        public virtual IQueryable<M> GetAll()
        {
            var entries = Enumerable.Empty<M>().AsQueryable();
            try
            {
                entries = _databaseService.GetTable<M>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return entries;

        }

        public virtual M GetSingle<P>(P pkValue)
        {
            var single = new M();
            try
            {
                single = _databaseService.GetTable<M>().Single(s => s.Id.Equals(pkValue));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return single;

        }

        public virtual System.Linq.IQueryable<M> Query(Expression<Func<M, bool>> whereCondition)
        {
            var entries = Enumerable.Empty<M>().AsQueryable();
            try
            {
                entries = _databaseService.GetTable<M>().Where(whereCondition);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return entries;
        }
    }
}