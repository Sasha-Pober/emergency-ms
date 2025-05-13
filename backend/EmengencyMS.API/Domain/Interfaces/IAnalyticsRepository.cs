using Domain.Entities.Analytics;

namespace Domain.Interfaces;

public interface IAnalyticsRepository
{
    Task<IEnumerable<RegionAnalytics>> GetRegionAnalyticsAsync(int regionId);
}
