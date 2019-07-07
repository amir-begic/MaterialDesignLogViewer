using MonitoringClient.Models;

namespace MonitoringClient.Services.RepositoryServices
{
    public class LocationRepository : RepositoryBase<LocationModel>
    {
        public LocationRepository(IDatabaseService<LocationModel> databaseService) : base(databaseService)
        {
        }
        public override string TableName => "location";
    }
}
