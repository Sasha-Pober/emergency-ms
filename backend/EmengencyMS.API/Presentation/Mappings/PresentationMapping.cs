using Domain.Entities;
using Presentation.Contracts.Emergency;
using Presentation.Contracts.EmergencyType;
using Presentation.Contracts.EmergencyTypes;
using Presentation.Contracts.Location;
using Presentation.Contracts.Source;
using Presentation.Enums;
using Services.DTO;
using System.Xml.Linq;

namespace Presentation.Mappings;

internal static class PresentationMapping
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
        };
    }

    internal static LocationResponse? MapLocation(this LocationDTO? dto)
    {
        if (dto == null) return null;

        return new LocationResponse
        {
            Id = dto.Id,
            Name = dto.Name,
            RegionType = dto.RegionTypeId.HasValue ? (RegionType)dto.RegionTypeId.Value : null,
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
            SourceType = dto.SourceTypeId.HasValue ? (SourceType)dto.SourceTypeId.Value : null
        };
    }

    internal static EmergencyDTO MapToDTO(this CreateEmergency entity)
    {
        return new EmergencyDTO
        {
            Title = entity.Title,
            Description = entity.Description,
            EmergencyTypeId = entity.EmergencyType,
            EmergencySubTypeId = entity.EmergencySubType,
            AccidentDate = entity.AccidentDate,
            DateEntered = DateTime.Now,
            Severity = entity.Severity,
            Casualties = entity.Casualties,
            Injured = entity.Injured,
            EconomicLoss = entity.EconomicLoss,
            Duration = entity.Duration,
            Location = entity.Location.MapToDTO(),
            Source = entity.Source.MapToDTO()
        };
    }

    internal static LocationDTO MapToDTO(this CreateLocation location)
    {
        return new LocationDTO
        {
            Name = location.Name,
            RegionTypeId = (int)location.RegionType,
            Latitude = location.Latitude,
            Longitude = location.Longitude
        };
    }

    internal static SourceDTO MapToDTO(this CreateSource source)
    {
        return new SourceDTO
        {
            Name = source.Name,
            Url = source.Url,
            SourceTypeId = (int)source.SourceType
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
}
