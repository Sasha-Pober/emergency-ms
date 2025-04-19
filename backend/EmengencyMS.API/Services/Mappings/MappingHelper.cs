using Domain.Entities;
using Services.DTO;

namespace Services.Mappings;

internal static class MappingHelper
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
            SourceType = source.SourceTypeId
        };
    }

}
