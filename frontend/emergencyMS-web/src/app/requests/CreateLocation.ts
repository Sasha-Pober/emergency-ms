export interface CreateLocation {
    name: string;
    regionTypeId?: number; // Define RegionType as an enum or type elsewhere
    latitude?: number;
    longitude?: number;
}