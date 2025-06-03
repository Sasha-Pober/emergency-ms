export interface CreateLocation {
    name: string;
    regionId?: number; // Define RegionType as an enum or type elsewhere
    latitude?: number;
    longitude?: number;
}