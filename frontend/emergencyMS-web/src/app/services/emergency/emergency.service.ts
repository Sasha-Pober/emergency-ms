import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Emergency } from '../../models/Emergency';
import { EmergencyTypeEntity } from '../../models/EmergencyTypeEntity';

@Injectable({
  providedIn: 'root'
})
export class EmergencyService {
  private readonly apiUrl = 'http://localhost:5030';

  constructor(private http: HttpClient) { }

  getAllEmergencies(page: number, pageSize: number): Observable<Emergency[]> {
    const params = new HttpParams()
      .set('page', page)
      .set('pageSize', pageSize);

    return this.http.get<Emergency[]>(`${this.apiUrl}/api/emergencies`, { params });
  }

  getEmergencyTypes(): Observable<EmergencyTypeEntity[]> {
    return this.http.get<EmergencyTypeEntity[]>(`${this.apiUrl}/api/emergencies/types`);
  }

  getEmergencySubTypes(): Observable<EmergencyTypeEntity[]> {
    return this.http.get<EmergencyTypeEntity[]>(`${this.apiUrl}/api/emergencies/subtypes`);
  }

  createEmergency(emergency: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}`, emergency);
  }

  getEmergenciesForPeriod(startDate: string, endDate: string): Observable<Emergency[]> {
    const params = new HttpParams()
      .set('startDate', startDate)
      .set('endDate', endDate);

    return this.http.get<Emergency[]>(`${this.apiUrl}/period`, { params });
  }
}
