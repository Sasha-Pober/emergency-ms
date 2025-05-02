using Domain.Entities;
using Services.DTO;

namespace Services.Mappings;

internal static class ServicesMapping
{
    internal static EmergencyDTO MapToDTO(this Emergency emergency)
    {
        return new EmergencyDTO
        {
            Id = emergency.Id,
            Title = emergency.Title,
            DateEntered = emergency.DateEntered,
            Description = emergency.Description,
            AccidentDate = emergency.AccidentDate,
            Casualties = emergency.Casualties,
            EmergencyTypeId = emergency.EmergencyTypeId,
            EmergencySubTypeId = emergency.EmergencySubTypeId,
            LocationId = emergency.LocationId,
            EconomicLoss = emergency.EconomicLoss,
            Severity = emergency.Severity,
            Injured = emergency.Injured,
            Duration = emergency.Duration,
            SourceId = emergency.SourceId,
            Location = emergency.Location.MapToDTO(),
            Source = emergency.Source.MapToDTO(),
        };
    }

    internal static LocationDTO MapToDTO(this Location location)
    {
        return new LocationDTO
        {
            Id = location.Id,
            Latitude = location.Latitude,
            Longitude = location.Longitude,
            Name = location.Name,
            RegionTypeId = location.RegionTypeId
        };
    }

    internal static SourceDTO MapToDTO(this Source source)
    {
        return new SourceDTO
        {
            Id = source.Id,
            Url = source.Url,
            Name = source.Name,
            SourceTypeId = source.SourceTypeId
        };
    }

    internal static Emergency MapToEntity(this EmergencyDTO emergencyDTO)
    {
        return new Emergency
        {
            Title = emergencyDTO.Title,
            DateEntered = emergencyDTO.DateEntered,
            Description = emergencyDTO.Description,
            AccidentDate = emergencyDTO.AccidentDate,
            Casualties = emergencyDTO.Casualties,
            EmergencyTypeId = emergencyDTO.EmergencyTypeId,
            EmergencySubTypeId = emergencyDTO.EmergencySubTypeId,
            EconomicLoss = emergencyDTO.EconomicLoss,
            Severity = emergencyDTO.Severity,
            Injured = emergencyDTO.Injured,
            Duration = emergencyDTO.Duration,
            Location = emergencyDTO.Location.MapToEntity(),
            Source = emergencyDTO.Source.MapToEntity(),
        };
    }

    internal static Location MapToEntity(this LocationDTO locationDTO)
    {
        return new Location
        {
            Latitude = locationDTO.Latitude,
            Longitude = locationDTO.Longitude,
            Name = locationDTO.Name,
            RegionTypeId = locationDTO.RegionTypeId
        };
    }

    internal static Source MapToEntity(this SourceDTO sourceDTO)
    {
        return new Source
        {
            Id = sourceDTO.Id,
            Url = sourceDTO.Url,
            Name = sourceDTO.Name,
            SourceTypeId = sourceDTO.SourceTypeId
        };

    }

    internal static EmergencyTypeDTO MapToDTO(this EmergencyType emergencyType)
    {
        return new EmergencyTypeDTO
        {
            Id = emergencyType.Id,
            Name = emergencyType.Name
        };
    }
}
