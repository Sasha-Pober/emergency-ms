namespace Domain.Entities.Analytics;

public class AnalyticsResponse
{
    public IList<AnalyticsResult> Results { get; set; }
    public IList<AnalyticsResult> BestAlternatives { get; set; }
}
