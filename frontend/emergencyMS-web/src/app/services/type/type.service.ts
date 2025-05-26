import { HttpClient } from '@angular/common/http';
import { Injectable, Type } from '@angular/core';
import { Observable } from 'rxjs';
import { TypeEntity } from '../../models/types/TypeEntity';
import { EmergencyTypeEntity } from '../../models/types/EmergencyTypeEntity';

@Injectable({
  providedIn: 'root'
})
export class TypeService {
  private readonly apiUrl = 'http://localhost:5030';

  constructor(private httpClient : HttpClient) {}

  getAllTypes() : Observable<TypeEntity> {
    return this.httpClient.get<TypeEntity>(`${this.apiUrl}/api/types`);
  }

  getEmergencyTypes(): Observable<EmergencyTypeEntity[]> {
      return this.httpClient.get<EmergencyTypeEntity[]>(`${this.apiUrl}/api/types`);
    }
  
    getEmergencySubTypes(): Observable<EmergencyTypeEntity[]> {
      return this.httpClient.get<EmergencyTypeEntity[]>(`${this.apiUrl}/api/subtypes`);
    }
}
