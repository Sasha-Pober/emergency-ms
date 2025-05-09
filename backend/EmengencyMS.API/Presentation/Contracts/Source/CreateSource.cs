namespace Presentation.Contracts.Source
{
    public class CreateSource
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public int? SourceTypeId { get; set; }
    }
}