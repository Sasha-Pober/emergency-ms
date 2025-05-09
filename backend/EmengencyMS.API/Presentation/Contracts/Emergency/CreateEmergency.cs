using Microsoft.AspNetCore.Http;
using Presentation.Contracts.Location;
using Presentation.Contracts.Source;
using Presentation.Contracts.Street;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Contracts.Emergency;

public class CreateEmergency
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int EmergencyType { get; set; }
    public int? EmergencySubType { get; set; }
    public DateTime AccidentDate { get; set; }
    [Range(1, 10)]
    public int? Severity { get; set; }
    public int? Casualties { get; set; }
    public int? Injured { get; set; }
    public decimal? EconomicLoss { get; set; }
    public double? Duration { get; set; }
    public CreateLocation Location { get; set; }
    public CreateSource Source { get; set; }
    public CreateStreet Street { get; set; }
    public IList<IFormFile> Images { get; set; }

}
