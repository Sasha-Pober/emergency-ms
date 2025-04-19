using Presentation.Contracts.Emergency;
using Presentation.Contracts.Location;
using Presentation.Contracts.Source;
using Presentation.Enums;
using Services.DTO;

namespace Presentation.Mappings;

internal static class MappingHelper
{
    internal static EmergencyResponse MapToResponse(this EmergencyDTO dto)
    {
        return new EmergencyResponse
        {
            Id = dto.Id,
            Title = dto.Title,
            EmergencyType = (EmergencyType)dto.EmergencyTypeId,
            EmergencySubType = dto.EmergencySubTypeId.HasValue ? (EmergencySubType)dto.EmergencySubTypeId : null,
            Description = dto.Description,
            AccidentDate = dto.AccidentDate,
            DateEntered = dto.DateEntered.HasValue ? dto.DateEntered : null,
            Severity = dto.Severity,
            Casualties = dto.Casualties,
            Injured = dto.Injured,
            EconomicLoss = dto.EconomicLoss,
            Duration = dto.Duration,
            Location = dto.Location.MapLocation(),
            Source = dto.Source.MapSource(),
        };
    }

    internal static LocationResponse MapLocation(this LocationDTO dto)
    {
        if (dto == null) return null;

        return new LocationResponse
        {
            Id = dto.Id,
            Name = dto.Name,
            RegionType = (RegionType)dto.RegionTypeId,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude
        };
    }

    internal static SourceResponse MapSource(this SourceDTO dto)
    {
        if (dto == null) return null;

        return new SourceResponse
        {
            Id = dto.Id,
            Name = dto.Name,
            Url = dto.Url,
            SourceType = (SourceType)dto.SourceType
        };
    }


}
