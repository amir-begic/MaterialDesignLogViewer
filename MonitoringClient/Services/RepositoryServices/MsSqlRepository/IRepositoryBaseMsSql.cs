using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringClient.Services.RepositoryServices.MsSqlRepository
{
    public interface IRepositoryBaseMsSql<M> where M : class
    {
        void Add(M entity);
        void Delete(M entity);
        void Update(object id, M entity);
        IQueryable<M> GetAll();
    }
}
