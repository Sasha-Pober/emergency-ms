import { SourceType } from "../enums/SourceType"

export interface Source {
    Id: number
    Name?: string 
    Url?: string 
    SourceType? : SourceType 
}