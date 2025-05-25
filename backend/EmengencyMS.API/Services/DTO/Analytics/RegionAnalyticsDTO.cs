namespace Services.DTO.Analytics;

public class RegionAnalyticsDTO
{
    public int RegionId { get; set; }
    public string RegionName { get; set; }
    public int TotalCasualties { get; set; }
    public int TotalInjured { get; set; }
    public double TotalLoss { get; set; }
    public double TotalHours { get; set; }
}
