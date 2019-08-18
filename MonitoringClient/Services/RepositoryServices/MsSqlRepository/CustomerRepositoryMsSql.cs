using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitoringClient.Models.EntityFramework;

namespace MonitoringClient.Services.RepositoryServices.MSSQLRepository
{
    class CustomerRepositoryMsSql : BaseRepositoryMsSql<Customer>
    {
        public CustomerRepositoryMsSql(IEntityFirstDatabaseService<Customer> databaseService) : base(databaseService)
        {

        }
    }
}
