import { Image } from "../models/Image";
import { CreateLocation } from "./CreateLocation";
import { CreateSource } from "./CreateSource";
import { CreateStreet } from "./CreateStreet";

export interface CreateEmergency {
    title?: string;
    description?: string;
    emergencyType: number;
    emergencySubType?: number;
    accidentDate: Date;
    severity?: number;
    casualties?: number;
    injured?: number;
    economicLoss?: number;
    duration?: number;
    location: CreateLocation;
    source: CreateSource;
    street: CreateStreet;
    images: File[];
    imagesEntities?: Image[];
    imagesToDelete?: string[];
}