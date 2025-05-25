namespace Presentation.Contracts.Analytics;

internal class RegionAnalyticsResponse
{
    public int RegionId { get; set; }
    public string RegionName { get; set; }
    public int TotalCasualties { get; set; }
    public int TotalInjured { get; set; }
    public double TotalLoss { get; set; }
    public double TotalHours { get; set; }
}
