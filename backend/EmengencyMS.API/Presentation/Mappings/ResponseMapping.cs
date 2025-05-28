using Presentation.Contracts.Analytics;
using Presentation.Contracts.Emergency;
using Presentation.Contracts.Image;
using Presentation.Contracts.Location;
using Presentation.Contracts.Source;
using Presentation.Contracts.Street;
using Presentation.Contracts.Types;
using Services.DTO;
using Services.DTO.Analytics;

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

    internal static EmergencyResponseWithImages MapToResponseWithImages(this EmergencyDTO dto)
    {
        return new EmergencyResponseWithImages
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
            Images = dto.Images.Select(x => x.MapToResponse()).ToList()
        };
    }

    internal static LocationResponse? MapLocation(this LocationDTO? dto)
    {
        if (dto == null) return null;

        return new LocationResponse
        {
            Id = dto.Id,
            Name = dto.Name,
            RegionId = dto.RegionId.Value,
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

    internal static RegionResponse MapToResponse(this RegionTypeDTO emergencyType)
    {
        return new RegionResponse
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

    internal static ImageResponse MapToResponse(this ImageDTO dto)
    {
        return new ImageResponse
        {
            Id = dto.Id,
            EmergencyId = dto.EmergencyId,
            FileName = dto.FileName,
            ImagePath = dto.ImagePath
        };
    }

    internal static RegionAnalyticsResponse MapToResponse(this RegionAnalyticsDTO dto)
    {
        return new RegionAnalyticsResponse
        {
            RegionId = dto.RegionId,
            RegionName = dto.RegionName,
            TotalCasualties = dto.TotalCasualties,
            TotalInjured = dto.TotalInjured,
            TotalLoss = dto.TotalLoss,
            TotalHours = dto.TotalHours
        };
    }

    internal static AnalyticsResponse MapToResponse(this AnalyticsResponseDTO dto)
    {
        return new AnalyticsResponse
        {
            BestAlternatives = dto.BestAlternatives.Select(a => a.MapToResponse()).ToList(),
            Results = dto.Results.Select(r => r.MapToResponse()).ToList()
        };
    }
}
