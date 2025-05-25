using Domain.Entities;
using Domain.Entities.Types;
using Services.DTO;

namespace Services.Mappings;

internal static class DTOMapping
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
            Street = emergency.Street.MapToDTO()
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
            RegionId = location.RegionId
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

    internal static EmergencyTypeDTO MapToDTO(this EmergencyType emergencyType)
    {
        return new EmergencyTypeDTO
        {
            Id = emergencyType.Id,
            Name = emergencyType.Name
        };
    }

    internal static EmergencySubTypeDTO MapToDTO(this EmergencySubType emergencyType)
    {
        return new EmergencySubTypeDTO
        {
            Id = emergencyType.Id,
            Name = emergencyType.Name
        };
    }

    internal static RegionTypeDTO MapToDTO(this Region emergencyType)
    {
        return new RegionTypeDTO
        {
            Id = emergencyType.Id,
            Name = emergencyType.Name
        };
    }

    internal static SourceTypeDTO MapToDTO(this SourceType emergencyType)
    {
        return new SourceTypeDTO
        {
            Id = emergencyType.Id,
            Name = emergencyType.Name
        };
    }

    internal static StreetDTO MapToDTO(this Street street)
    {
        return new StreetDTO
        {
            Id = street.Id,
            StreetName = street.StreetName,
            HouseNr = street.HouseNr
        };
    }

    internal static TypeDTO MapToDTO(this TypeEntity type)
    {
        return new TypeDTO
        {
            Types = type.Types.Select(x => x.MapToDTO()),
            SubTypes = type.SubTypes.Select(x => x.MapToDTO()),
            RegionTypes = type.Regions.Select(x => x.MapToDTO()),
            SourceTypes = type.SourceTypes.Select(x => x.MapToDTO()),
        };
    }
}
