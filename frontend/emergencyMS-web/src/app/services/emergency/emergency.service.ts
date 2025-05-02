import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Emergency } from '../../models/Emergency'; // Adjust the import path as necessary
import { EmergencyTypeEntity } from '../../models/EmergencyTypeEntity';

@Injectable({
  providedIn: 'root'
})
export class EmergencyService {
  private readonly apiUrl = 'http://localhost:5030'; // Base API URL
  
  constructor(private http: HttpClient) {}
  
  /**
   * Get all emergencies with pagination.
   * @param page The page number.
   * @param pageSize The number of items per page.
   * @returns An observable of the emergencies list.
  */
 getAllEmergencies(page: number, pageSize: number): Observable<Emergency[]> {
   const params = new HttpParams()
   .set('page', page)
   .set('pageSize', pageSize);
   
   return this.http.get<Emergency[]>(`${this.apiUrl}/api/emergencies`, { params });
  }
  
  getEmergencyTypes(): Observable<EmergencyTypeEntity[]> {
    return this.http.get<EmergencyTypeEntity[]>(`${this.apiUrl}/api/emergencies/types`);
  }
  /**
   * Create a new emergency.
   * @param emergency The emergency object to create.
   * @returns An observable of the created emergency.
   */
  createEmergency(emergency: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}`, emergency);
  }

  /**
   * Get emergencies for a specific period.
   * @param startDate The start date of the period.
   * @param endDate The end date of the period.
   * @returns An observable of the emergencies list.
   */
  getEmergenciesForPeriod(startDate: string, endDate: string): Observable<Emergency[]> {
    const params = new HttpParams()
      .set('startDate', startDate)
      .set('endDate', endDate);

    return this.http.get<Emergency[]>(`${this.apiUrl}/period`, { params });
  }
}
