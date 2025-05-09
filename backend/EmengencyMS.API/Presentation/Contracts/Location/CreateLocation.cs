namespace Presentation.Contracts.Location
{
    public class CreateLocation
    {
        public string Name { get; set; }
        public int? RegionTypeId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}