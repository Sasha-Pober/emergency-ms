using Presentation.Enums;
using Services.DTO;

namespace Presentation.Requests;

public class CreateEmergency
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public EmergencyType EmergencyType { get; set; }
    public EmergencySubType EmergencySubType { get; set; }
    public DateTime AccidentDate { get; set; }
    public int? Severity { get; set; }
    public int? Casualties { get; set; }
    public int? Injured { get; set; }
    public decimal? EconomicLoss { get; set; }
    public double? Duration { get; set; }
    public CreateLocation Location { get; set; }
    public CreateSource Source { get; set; }


    public EmergencyDTO MapToDTO()
    {
        return new EmergencyDTO
        {
            Title = Title,
            Description = Description,
            EmergencyTypeId = (int)EmergencyType,
            AccidentDate = AccidentDate,
            DateEntered = DateTime.Now,
            Severity = Severity,
            Casualties = Casualties,
            Injured = Injured,
            EconomicLoss = EconomicLoss,
            Duration = Duration,
            Location = Location.MapToDTO(),
            Source = Source.MapToDTO()
        };
    }

}
