using Domain.Interfaces;
using Services.DTO.Analytics;
using Services.Interfaces;
using Services.Mappings;

namespace Services.Implementations;

internal class AnalyticsService(IAnalyticsRepository analyticsRepository, IVikorSolver vikorSolver) : IAnalyticsService
{
    public async Task<AnalyticsResponseDTO> GetAnalyticsResults()
    {
        var data = await analyticsRepository.GetRegionsAnalyticsAsync();

        var vikorResults = vikorSolver.GetAnalytics(data);

        return vikorResults.MapToDTO();
    }
}
