import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MapService {

  private readonly filePath = 'assets\\geoBoundaries-UKR-ADM1_simplified.geojson';

  constructor(private http: HttpClient) { }

  getGeoJsonData(): Observable<any> {
    return this.http.get(this.filePath);
  }
}
