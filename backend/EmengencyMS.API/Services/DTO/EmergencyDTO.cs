namespace Services.DTO;

public class EmergencyDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int EmergencyTypeId { get; set; }
    public DateTime AccidentDate { get; set; }
    public DateTime? DateEntered { get; set; }
    public int LocationId { get; set; }
    public int? Severity { get; set; }
    public int? Casualties { get; set; }
    public int? Injured { get; set; }
    public decimal? EconomicLoss { get; set; }
    public double? Duration { get; set; }
    public int? SourceId { get; set; }
    public string? Description { get; set; }
    public LocationDTO Location { get; set; }
    public SourceDTO Source { get; set; }
}
