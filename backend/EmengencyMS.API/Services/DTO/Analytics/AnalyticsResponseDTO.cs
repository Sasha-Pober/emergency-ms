namespace Services.DTO.Analytics;

public class AnalyticsResponseDTO
{
    public List<RegionAnalyticsDTO> Results { get; set; }
    public List<RegionAnalyticsDTO> BestAlternatives { get; set; }
}
