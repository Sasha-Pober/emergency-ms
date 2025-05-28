import { Source } from "./Source";
import { Street } from "./Street";
import { Location } from "./Location";
import { Image } from "./Image";

export interface EmergencyWithImages {
    id: number;
    title?: string;
    description?: string;
    emergencyType?: number;
    emergencySubType?: number;
    accidentDate: Date;
    dateEntered?: Date;
    severity?: number;
    casualties?: number;
    injured?: number;
    economicLoss?: number;
    duration?: number;
    location: Location;
    source: Source;
    street: Street;
    images?: Image[]; // Array of image URLs
}