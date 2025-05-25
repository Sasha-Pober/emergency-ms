using Domain.Entities.Analytics;
using Services.DTO.Analytics;

namespace Services.Mappings;

internal static class AnalyticsMapping
{
    internal static AnalyticsResponseDTO MapToDTO(this AnalyticsResponse vikorResults)
    {
        return new AnalyticsResponseDTO
        {
            BestAlternatives = vikorResults.BestAlternatives.Select(x => new RegionAnalyticsDTO
            {
                RegionId = x.RegionId,
                RegionName = x.RegionName,
                TotalCasualties = x.TotalCasualties,
                TotalInjured = x.TotalInjured,
                TotalLoss = x.TotalLoss,
                TotalHours = x.TotalHours
            }).ToList(),

            Results = vikorResults.Results.Select(x => new RegionAnalyticsDTO
            {
                RegionId = x.RegionId,
                RegionName = x.RegionName,
                TotalCasualties = x.TotalCasualties,
                TotalInjured = x.TotalInjured,
                TotalLoss = x.TotalLoss,
                TotalHours = x.TotalHours
            }).ToList()
        };
    }
}
