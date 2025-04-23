using Presentation.Enums;

namespace Presentation.Contracts.Location;

internal class LocationResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public RegionType? RegionType { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}