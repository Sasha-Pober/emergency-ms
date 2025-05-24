namespace Services.DTO.Analytics;

public class AnalyticsResponseDTO
{
    public IList<AnalyticsResultDTO> Results { get; set; }
    public IList<AnalyticsResultDTO> BestAlternatives { get; set; }
}
