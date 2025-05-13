namespace Domain.Entities.Analytics;

public class RegionAnalytics
{
    public int RegionId { get; set; }
    public string RegionName { get; set; }
    public int TotalCasualties { get; set; }
    public int TotalInjured { get; set; }
    public decimal TotalLoss { get; set; }
    public double TotalHours { get; set; }
}
