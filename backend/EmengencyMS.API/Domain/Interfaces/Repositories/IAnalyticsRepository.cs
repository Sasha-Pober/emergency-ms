using Domain.Entities.Analytics;

namespace Domain.Interfaces.Repositories;

public interface IAnalyticsRepository
{
    Task<IEnumerable<RegionAnalytics>> GetRegionsAnalyticsAsync();
}
