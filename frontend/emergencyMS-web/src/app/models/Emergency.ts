import { Source } from "./Source";
import { Location } from "./Location";

export interface Emergency {
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
}