using Presentation.Contracts.Emergency;
using Presentation.Contracts.Location;
using Presentation.Contracts.Source;
using Presentation.Contracts.Street;
using Presentation.Contracts.Types;
using Services.DTO;

namespace Presentation.Mappings;

internal static class ResponseMapping
{
    internal static EmergencyResponse MapToResponse(this EmergencyDTO dto)
    {
        return new EmergencyResponse
        {
            Id = dto.Id,
            Title = dto.Title,
            EmergencyType = dto.EmergencyTypeId,
            EmergencySubType = dto.EmergencySubTypeId,
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
            Street = dto.Street.MapToResponse(),
        };
    }

    internal static LocationResponse? MapLocation(this LocationDTO? dto)
    {
        if (dto == null) return null;

        return new LocationResponse
        {
            Id = dto.Id,
            Name = dto.Name,
            RegionTypeId = dto.RegionTypeId.Value,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude
        };
    }

    internal static SourceResponse? MapSource(this SourceDTO dto)
    {
        if (dto == null) return null;

        return new SourceResponse
        {
            Id = dto.Id,
            Name = dto.Name,
            Url = dto.Url,
            SourceTypeId = dto.SourceTypeId
        };
    }

    internal static EmergencyTypeResponse MapToResponse(this EmergencyTypeDTO emergencyType)
    {
        return new EmergencyTypeResponse
        {
            Id = emergencyType.Id,
            Name = emergencyType.Name,
        };
    }

    internal static EmergencySubTypeResponse MapToResponse(this EmergencySubTypeDTO emergencyType)
    {
        return new EmergencySubTypeResponse
        {
            Id = emergencyType.Id,
            Name = emergencyType.Name,
        };
    }

    internal static RegionTypeResponse MapToResponse(this RegionTypeDTO emergencyType)
    {
        return new RegionTypeResponse
        {
            Id = emergencyType.Id,
            Name = emergencyType.Name,
        };
    }

    internal static SourceTypeResponse MapToResponse(this SourceTypeDTO emergencyType)
    {
        return new SourceTypeResponse
        {
            Id = emergencyType.Id,
            Name = emergencyType.Name,
        };
    }

    internal static StreetResponse MapToResponse(this StreetDTO street)
    {
        return new StreetResponse
        {
            Id = street.Id,
            StreetName = street.StreetName,
            HouseNr = street.HouseNr
        };
    }

    internal static TypeResponse MapToResponse(this TypeDTO type)
    {
        return new TypeResponse
        {
            Types = type.Types.Select(t => t.MapToResponse()),
            SubTypes = type.SubTypes.Select(t => t.MapToResponse()),
            RegionTypes = type.RegionTypes.Select(t => t.MapToResponse()),
            SourceTypes = type.SourceTypes.Select(t => t.MapToResponse()),
        };
    }
}
