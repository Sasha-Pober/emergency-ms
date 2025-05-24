using Services.DTO.Analytics;

namespace Services.Interfaces;

public interface IAnalyticsService
{
    Task<AnalyticsResponseDTO> GetAnalyticsResults();
}
