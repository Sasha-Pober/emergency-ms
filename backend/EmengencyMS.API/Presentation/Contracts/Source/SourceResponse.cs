namespace Presentation.Contracts.Source;

internal class SourceResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
    public int? SourceTypeId { get; set; }
}