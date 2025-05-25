namespace Presentation.Contracts.Analytics;

internal class AnalyticsResponse
{
    public IList<RegionAnalyticsResponse> Results { get; set; }
    public IList<RegionAnalyticsResponse> BestAlternatives { get; set; }
}
