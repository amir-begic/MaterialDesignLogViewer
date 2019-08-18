using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringClient.Services
{
    public class EntityFirstDatabaseService<M> : DbContext, IEntityFirstDatabaseService<M> where M : class
    {
        public DbSet<M> DataSet { get; set; }
        public DbContext Context { get; set; }
        public string TableName => throw new NotImplementedException();

        public EntityFirstDatabaseService() : base("InventarisierungsloesungEntities")
        {
            Context = this;
        }
        
    }
}
