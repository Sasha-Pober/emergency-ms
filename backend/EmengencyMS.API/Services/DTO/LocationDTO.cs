﻿namespace Services.DTO;

public class LocationDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? RegionId { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}
