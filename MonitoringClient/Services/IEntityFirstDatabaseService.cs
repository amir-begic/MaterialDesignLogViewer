using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitoringClient.Services.RepositoryServices;

namespace MonitoringClient.Services
{
    public interface IEntityFirstDatabaseService<M> where M : class
    {
        DbSet<M> DataSet { get; set; }
        DbContext Context { get; set; }
    }
}
