namespace Domain.Entities;

public class Source
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
    public int? SourceTypeId { get; set; }
}