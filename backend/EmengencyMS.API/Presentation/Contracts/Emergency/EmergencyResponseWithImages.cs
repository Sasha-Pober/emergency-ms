using Presentation.Contracts.Image;
using Presentation.Contracts.Location;
using Presentation.Contracts.Source;
using Presentation.Contracts.Street;

namespace Presentation.Contracts.Emergency;

internal class EmergencyResponseWithImages
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? EmergencyType { get; set; }
    public int? EmergencySubType { get; set; }
    public DateTime AccidentDate { get; set; }
    public DateTime? DateEntered { get; set; }
    public int? Severity { get; set; }
    public int? Casualties { get; set; }
    public int? Injured { get; set; }
    public decimal? EconomicLoss { get; set; }
    public double? Duration { get; set; }
    public LocationResponse Location { get; set; }
    public SourceResponse Source { get; set; }
    public StreetResponse Street { get; set; }
    public List<ImageResponse> Images { get; set; }
}
