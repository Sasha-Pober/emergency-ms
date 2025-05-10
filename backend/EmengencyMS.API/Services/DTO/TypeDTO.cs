namespace Services.DTO
{
    public class TypeDTO
    {
        public IEnumerable<EmergencyTypeDTO> Types { get; set; }
        public IEnumerable<EmergencySubTypeDTO> SubTypes { get; set; }
        public IEnumerable<RegionTypeDTO> RegionTypes { get; set; }
        public IEnumerable<SourceTypeDTO> SourceTypes { get; set; }
    }
}