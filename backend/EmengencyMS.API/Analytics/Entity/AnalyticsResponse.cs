namespace Analytics.Entity;

public class AnalyticsResponse
{
    public IList<AnalyticsResult> Results { get; set; }
    public IList<AnalyticsResult> BestAlternatives { get; set; }
}
