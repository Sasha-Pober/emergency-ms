using Dapper;
using Domain.Entities.Analytics;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories
{
    internal class AnalyticsRepository(SqlConnection connection) : IAnalyticsRepository
    {
        public Task<IEnumerable<RegionAnalytics>> GetRegionsAnalyticsAsync()
        {
            return connection.QueryAsync<RegionAnalytics>(
                "[dbo].[GetAnalyticsByRegion]",
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
