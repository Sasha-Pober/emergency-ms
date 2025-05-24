using Domain.Entities.Analytics;

namespace Domain.Interfaces;

public interface IVikorSolver
{
    AnalyticsResponse GetAnalytics(IEnumerable<RegionAnalytics> info);
}
