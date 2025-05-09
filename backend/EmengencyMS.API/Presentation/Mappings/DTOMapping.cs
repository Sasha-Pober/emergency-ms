using Presentation.Contracts.Emergency;
using Presentation.Contracts.Location;
using Presentation.Contracts.Source;
using Presentation.Contracts.Street;
using Services.DTO;

namespace Presentation.Mappings;

internal static class DTOMapping
{
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
            Source = entity.Source.MapToDTO(),
            Street = entity.Street.MapToDTO()
        };
    }

    internal static LocationDTO MapToDTO(this CreateLocation location)
    {
        return new LocationDTO
        {
            Name = location.Name,
            RegionTypeId = location.RegionTypeId,
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
            SourceTypeId = source.SourceTypeId
        };
    }

    internal static StreetDTO MapToDTO(this CreateStreet street)
    {
        return new StreetDTO
        {
            StreetName = street.StreetName,
            HouseNr = street.HouseNr
        };
    }
}
