using Services.DTO;

namespace Presentation.Contracts.Location
{
    public class CreateLocation
    {
        public string Name { get; set; }
        public RegionType? RegionType { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        internal LocationDTO MapToDTO()
        {
            return new LocationDTO
            {
                Name = Name,
                RegionTypeId = (int)RegionType,
                Latitude = Latitude,
                Longitude = Longitude
            };
        }
    }
}