namespace Domain.Entities;

public class Emergency
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int EmergencyTypeId { get; set; }
    public int? EmergencySubTypeId { get; set; }
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
    public Location Location { get; set; }
    public Source Source { get; set; }
    public Street Street { get; set; }
}

