import { RegionType } from "../enums/RegionType";

export interface Location {
    id: number;
    name: string;
    regionType?: RegionType;
    latitude?: number;
    longitude?: number;
}