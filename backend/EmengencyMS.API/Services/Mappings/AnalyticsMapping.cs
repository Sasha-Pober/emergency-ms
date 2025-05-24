using Domain.Entities.Analytics;
using Services.DTO.Analytics;

namespace Services.Mappings;

internal static class AnalyticsMapping
{
    internal static AnalyticsResponseDTO MapToDTO(this AnalyticsResponse vikorResults)
    {
        return new AnalyticsResponseDTO
        {
            BestAlternatives = vikorResults.BestAlternatives.Select(x => new AnalyticsResultDTO
            {
                Name = x.Name,
                S = x.S,
                R = x.R,
                Q = x.Q,
            }).ToList(),
            Results = vikorResults.Results.Select(x => new AnalyticsResultDTO
            {
                Name = x.Name,
                S = x.S,
                R = x.R,
                Q = x.Q,
            }).ToList()
        };
    }
}
