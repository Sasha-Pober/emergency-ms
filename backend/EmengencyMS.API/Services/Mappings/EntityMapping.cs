using Domain.Entities;
using Services.DTO;

namespace Services.Mappings;

internal static class EntityMapping
{

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
            Street = emergencyDTO.Street.MapToEntity()
        };
    }

    internal static Location MapToEntity(this LocationDTO locationDTO)
    {
        return new Location
        {
            Latitude = locationDTO.Latitude,
            Longitude = locationDTO.Longitude,
            Name = locationDTO.Name,
            RegionId = locationDTO.RegionId
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

    internal static Street MapToEntity(this StreetDTO streetDTO)
    {
        return new Street
        {
            Id = streetDTO.Id,
            StreetName = streetDTO.StreetName,
            HouseNr = streetDTO.HouseNr
        };
    }
}
