namespace Domain.Entities.Analytics;

public class AnalyticsResponse
{
    public List<RegionAnalytics> Results { get; set; }
    public List<RegionAnalytics> BestAlternatives { get; set; }
}
