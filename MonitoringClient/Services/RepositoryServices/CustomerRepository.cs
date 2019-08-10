using MonitoringClient.Models;

namespace MonitoringClient.Services.RepositoryServices
{
    public class CustomerRepository : RepositoryBase<CustomerModel>
    {
        public CustomerRepository(IDatabaseService<CustomerModel> databaseService) : base(databaseService)
        {
        }
    }
}