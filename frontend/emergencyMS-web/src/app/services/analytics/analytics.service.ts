import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AnalyticsResponse } from '../../models/Analytics/AnalyticsResponse';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AnalyticsService {

  private readonly apiUrl = 'http://localhost:5030/api';

  constructor(private http: HttpClient) { }

  getAnalyticsData() : Observable<AnalyticsResponse> {
    return this.http.get<AnalyticsResponse>(`${this.apiUrl}/analytics`);
  }
}
