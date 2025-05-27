import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Emergency } from '../../models/Emergency';
import { EmergencyTypeEntity } from '../../models/types/EmergencyTypeEntity';
import { CreateEmergency } from '../../requests/CreateEmergency';
import { AuthService } from '../auth/auth.service';
import { EmergencyWithImages } from '../../models/EmergencyWithImages';

@Injectable({
  providedIn: 'root'
})
export class EmergencyService {
  private readonly apiUrl = 'http://localhost:5030';

  constructor(private http: HttpClient, private authService: AuthService) { }

  getAllEmergencies(page: number, pageSize: number): Observable<Emergency[]> {
    const params = new HttpParams()
      .set('page', page)
      .set('pageSize', pageSize);

    return this.http.get<Emergency[]>(`${this.apiUrl}/api/emergencies`, { params });
  }

  createEmergency(emergency: CreateEmergency): Observable<CreateEmergency> {

    const headers = {
      Authorization: this.authService.getToken() || ''
    };

    const formData = this.ConvertToFormData(emergency);

    return this.http.post<CreateEmergency>(`${this.apiUrl}/api/emergencies`, formData, { headers });
  }

  getEmergenciesForPeriod(startDate: string, endDate: string): Observable<Emergency[]> {
    const params = new HttpParams()
      .set('startDate', startDate)
      .set('endDate', endDate);

    return this.http.get<Emergency[]>(`${this.apiUrl}/period`, { params });
  }

  getEmergencyById(id: number): Observable<EmergencyWithImages> {
    return this.http.get<EmergencyWithImages>(`${this.apiUrl}/api/emergencies/${id}`);
  }

  private ConvertToFormData(emergency: CreateEmergency): FormData {
    const formData = new FormData();

    // Append simple fields
    // Append simple fields
    this.appendFormData(formData, 'Title', emergency.title);
    this.appendFormData(formData, 'Description', emergency.description);
    this.appendFormData(formData, 'EmergencyType', emergency.emergencyType);
    this.appendFormData(formData, 'EmergencySubType', emergency.emergencySubType);
    this.appendFormData(formData, 'AccidentDate', emergency.accidentDate);
    this.appendFormData(formData, 'Severity', emergency.severity);
    this.appendFormData(formData, 'Casualties', emergency.casualties);
    this.appendFormData(formData, 'Injured', emergency.injured);
    this.appendFormData(formData, 'EconomicLoss', emergency.economicLoss);
    this.appendFormData(formData, 'Duration', emergency.duration);

    // Append nested objects
    this.appendFormData(formData, 'Location.Name', emergency.location.name);
    this.appendFormData(formData, 'Location.RegionTypeId', emergency.location.regionTypeId);
    this.appendFormData(formData, 'Location.Latitude', emergency.location.latitude);
    this.appendFormData(formData, 'Location.Longitude', emergency.location.longitude);

    this.appendFormData(formData, 'Source.Name', emergency.source.name);
    this.appendFormData(formData, 'Source.Url', emergency.source.url);
    this.appendFormData(formData, 'Source.SourceTypeId', emergency.source.sourceTypeId);

    this.appendFormData(formData, 'Street.StreetName', emergency.street.streetName);
    this.appendFormData(formData, 'Street.HouseNr', emergency.street.houseNr);

    // Append files
    if (emergency.images && emergency.images.length > 0) {
      emergency.images.forEach((file) => {
        formData.append('Images', file);
      });
    }
    return formData;
  }

  private appendFormData(formData: FormData, key: string, value: any): void {
    if (value !== null && value !== undefined) {
      if (typeof value === 'number' && (key === 'Location.Latitude' || key === 'Location.Longitude')) {
        formData.append(key, value.toString().replace('.', ',')); // Format numbers with a comma
      } else {
        formData.append(key, value.toString());
      }
    }
  }
}
