import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import * as L from 'leaflet';
import { EmergencyService } from '../../services/emergency/emergency.service';
import { Emergency } from '../../models/Emergency';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnChanges {
  @Input() filteredType: number = 0; // Input for filtering emergencies by type
  @Input() filteredSubType: number = 0; // Input for filtering emergencies by type

  private map: L.Map | any;
  //private markers: { lat: number; lng: number; popupTitle: string, popupDescription: string}[] = [];
  private emergencies: Emergency[] = [];

  private mainIcon = L.icon(
    {
      iconUrl: `../../assets/marker-blue.png`,
      iconSize: [30.5, 50],
      iconAnchor: [12, 41],
      popupAnchor: [1, -31],
      shadowSize: [41, 41]
    });

  constructor(private emergencyService: EmergencyService) { }

  ngOnChanges(changes: SimpleChanges): void {
    this.updateMarkers(this.filteredType, this.filteredSubType);
  }

  ngOnInit(): void {
    this.initMap();
    this.fetchEmergencies();
  }

  private fetchEmergencies(): void {
    this.emergencyService.getAllEmergencies(1, 100).subscribe(data => {
      this.emergencies = data;
      // this.markers = data
      //   .filter(dat => (!this.filteredType || dat.emergencyType === this.filteredType)
      //     && (!this.filteredSubType || dat.emergencySubType === this.filteredSubType))
      //   .map(dat => ({
      //     lat: dat.location.latitude!,
      //     lng: dat.location.longitude!,
      //     popupTitle: dat.title!,
      //     popupDescription: dat.description!
      //   }));
      this.updateMarkers();
    });
  }

  private updateMarkers(type: number = 0, subType: number = 0): void {
    //let markersToAdd = this.markers;
    let emergenciesQuery: Emergency[] = this.emergencies;

    if (!this.map) {
      console.error('Map is not initialized');
      return;
    }

    console.log('Filtered Type:', this.filteredType);
    console.log('Filtered SubType:', this.filteredSubType);

    // Clear existing markers
    this.map.eachLayer((layer: L.Marker) => {
      if (layer instanceof L.Marker) {
        this.map.removeLayer(layer);
      }
    });

    emergenciesQuery = this.emergencies.filter(dat => {
      if (type !== 0 && subType !== 0) {
        return dat.emergencyType === type && dat.emergencySubType === subType;
      } else if (type !== 0) {
        return dat.emergencyType === type;
      } else if (subType !== 0) {
        return dat.emergencySubType === subType;
      }
      return true;
    });
    console.log('Filtered Emergencies:', emergenciesQuery);


    // markersToAdd = emergenciesQuery
    //   .map(dat => ({
    //     lat: dat.location.latitude!,
    //     lng: dat.location.longitude!,
    //     popupTitle: dat.title!,
    //     popupDescription: dat.description!
    //   }));

    // Add new markers
    emergenciesQuery.forEach(emer => {
      L.marker([emer.location.latitude!, emer.location.longitude!], {
        icon: this.mainIcon
      })
        .addTo(this.map)
        .bindPopup(`<h3>${emer.title}</h3>${emer.description}<br> вул. ${emer.street.streetName}, ${emer.street.houseNr!}`);
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