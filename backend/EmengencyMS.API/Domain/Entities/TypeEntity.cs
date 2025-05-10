using Domain.Entities.Types;

namespace Domain.Entities;

public class TypeEntity
{
    public IEnumerable<EmergencyType> Types { get; set; }
    public IEnumerable<EmergencySubType> SubTypes { get; set; }
    public IEnumerable<RegionType> RegionTypes { get; set; }
    public IEnumerable<SourceType> SourceTypes { get; set; }
}