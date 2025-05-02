import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import * as L from 'leaflet';
import { EmergencyService } from '../../services/emergency/emergency.service';
import { EmergencyType } from '../../enums/EmergencyType';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnChanges {
  @Input() filteredType: string = ''; // Input for filtering emergencies by type

  private map: L.Map | any;
  private markers: { lat: number; lng: number; popup: string }[] = [];

  constructor(private emergencyService: EmergencyService) {}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['filteredType']) {
      this.updateMarkers();
    }
  }

  ngOnInit(): void {
    this.initMap();
    this.fetchEmergencies();
  }

  private fetchEmergencies(): void {
    this.emergencyService.getAllEmergencies(1, 100).subscribe(data => {
      this.markers = data
        .filter(dat => !this.filteredType || dat.emergencyType?.toString() === this.filteredType)
        .map(dat => ({
          lat: dat.location.latitude!,
          lng: dat.location.longitude!,
          popup: dat.description!
        }));
      this.updateMarkers();
    });
  }

  private updateMarkers(): void {
    if (!this.map) {
      console.error('Map is not initialized');
      return;
    }

    // Clear existing markers
    this.map.eachLayer((layer: L.Marker) => {
      if (layer instanceof L.Marker) {
        this.map.removeLayer(layer);
      }
    });

    // Add new markers
    this.markers.forEach(marker => {
      L.marker([marker.lat, marker.lng])
        .addTo(this.map)
        .bindPopup(marker.popup);
    });
  }

  private initMap(): void {
    this.map = L.map('map', {
      center: [48.505, 32.09],
      zoom: 7
    });

    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 19,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(this.map);
  }
}