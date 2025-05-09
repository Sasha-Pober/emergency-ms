import { EmergencySubType } from "./EmergencySubType";
import { EmergencyTypeEntity } from "./EmergencyTypeEntity";
import { RegionType } from "./RegionType";
import { SourceType } from "./SourceType";

export interface TypeEntity {
    types: EmergencyTypeEntity[];
    subtypes : EmergencySubType[];
    regionTypes: RegionType[];
    sourceTypes: SourceType[];
}