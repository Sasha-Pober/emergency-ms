import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import * as L from 'leaflet';
import { EmergencyService } from '../../services/emergency/emergency.service';
import { Emergency } from '../../models/Emergency';
import { MapService } from '../../services/map/map.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnChanges {
  @Input() filteredType: number = 0; // Input for filtering emergencies by type
  @Input() filteredSubType: number = 0; // Input for filtering emergencies by type

  private map: L.Map | any;
  private geoJson: L.GeoJSON | any;
  private defaultStyle = {
    color: '#3388ff',
    weight: 2,
    fillOpacity: 0.1
  };
  private emergencies: Emergency[] = [];
  private originalEmergencies: Emergency[] = [];
  private statesData: any;


  private mainIcon = L.icon(
    {
      iconUrl: `../../assets/image.png`,
      iconSize: [30, 35],
      iconAnchor: [12, 41],
      popupAnchor: [1, -31],
      shadowSize: [41, 41]
    });

  constructor(
    private emergencyService: EmergencyService, 
    private mapService: MapService,
    private router: Router) { }

  ngOnChanges(changes: SimpleChanges): void {
    this.updateMarkers(this.filteredType, this.filteredSubType);
  }

  ngOnInit(): void {
    this.initMap();
    this.GetStateBoundaries();
    this.fetchEmergencies();
  }

  private GetStateBoundaries(): void {
    this.mapService.getGeoJsonData().subscribe(data => {
      this.statesData = data;

      this.geoJson = L.geoJson(this.statesData, {
        style: this.defaultStyle,
        onEachFeature: (feature, layer) => {
          layer.on({
            mouseover: this.highlightFeature,
            mouseout: this.resetHighlight,
            click: this.zoomToFeature.bind(this)
          });
        }
      }).addTo(this.map);

      this.map.fitBounds(this.geoJson.getBounds()); // автоцентрування карти
    });
  }

  highlightFeature(e: any): void {
    var layer = e.target;

    layer.setStyle({
      weight: 5,
      color: 'yellow',
      dashArray: '',
      fillOpacity: 0.1
    });

    layer.bringToFront();
  }

  resetHighlight(e: any): void {
    var layer = e.target;

    layer.setStyle({
      weight: 2,
      color: '#3388ff',
      dashArray: '',
      fillOpacity: 0.1
    });

    layer.bringToBack();
  }

  zoomToFeature(e : any): void {
    this.fetchEmergenciesByCoords([e.target._bounds._northEast, e.target._bounds._southWest]);
    this.map.fitBounds(e.target.getBounds());
  }


  private fetchEmergencies(): void {
    this.emergencyService.getAllEmergencies(1, 100).subscribe(data => {
      this.emergencies = data;
      this.originalEmergencies = data;
      this.updateMarkers(this.filteredType, this.filteredSubType);
    });
  }

  private fetchEmergenciesByCoords(coords: {lat: number, lng: number}[]): void {
    console.log('Fetching emergencies by coordinates:', coords);
  }

  private updateMarkers(type: number = 0, subType: number = 0): void {
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

    // Add new markers
    emergenciesQuery.forEach(emer => {
      L.marker([emer.location.latitude!, emer.location.longitude!], {
        icon: this.mainIcon,
      })
        .addTo(this.map)
        .addEventListener('click', () => {
          this.router.navigate(['main/emergencyInfo/', emer.id]);
          console.log('Marker clicked:', emer.id);
        })
        .bindPopup(`<h3>${emer.title}</h3>${emer.description}<br> вул. ${emer.street.streetName}, ${emer.street.houseNr!}<br>
          <a href="/emergency/${emer.id}">Детальніше</a>`);
    });
  }

  private initMap(): void {
    this.map = L.map('map', {
      center: [48.505, 32.09],
      zoomControl: true,
      zoom: 6,
      minZoom: 6,
      maxBounds: [[44,22], [52, 40]],
      maxBoundsViscosity: 1.0,
    });

    this.map.zoomControl.setPosition('bottomright'); // Set zoom control position
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 19,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(this.map);
  }
}