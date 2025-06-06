﻿namespace Presentation.Contracts.Types;

internal class TypeResponse
{
    internal IEnumerable<EmergencyTypeResponse> Types { get; set; }
    internal IEnumerable<EmergencySubTypeResponse> SubTypes { get; set; }
    internal IEnumerable<RegionResponse> RegionTypes { get; set; }
    internal IEnumerable<SourceTypeResponse> SourceTypes { get; set; }
}
