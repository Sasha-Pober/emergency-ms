using Presentation.Contracts.Location;
using Presentation.Contracts.Source;
using Presentation.Enums;
using Services.DTO;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Contracts.Emergency;

public class CreateEmergency
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public EmergencyType EmergencyType { get; set; }
    public EmergencySubType EmergencySubType { get; set; }
    public DateTime AccidentDate { get; set; }
    [Range(1, 10)]
    public int? Severity { get; set; }
    public int? Casualties { get; set; }
    public int? Injured { get; set; }
    public decimal? EconomicLoss { get; set; }
    public double? Duration { get; set; }
    public CreateLocation Location { get; set; }
    public CreateSource Source { get; set; }

}
