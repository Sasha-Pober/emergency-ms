using Domain.Entities.Analytics;

namespace Domain.Interfaces.Analytics;

public interface IVikorSolver
{
    AnalyticsResponse GetAnalytics(IEnumerable<RegionAnalytics> info);
}
