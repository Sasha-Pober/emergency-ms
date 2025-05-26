import { RegionAnalyticsResponse } from "./RegionAnalyticsResponse";

export interface AnalyticsResponse {
  results: RegionAnalyticsResponse[];
  bestAlternatives: RegionAnalyticsResponse[];
}