import { Component, OnInit } from '@angular/core';
import { EmergencyService } from '../../services/emergency/emergency.service';
import { EmergencyType } from '../../enums/EmergencyType';
import { EmergencyTypeEntity } from '../../models/EmergencyTypeEntity';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  emergencyTypes: EmergencyTypeEntity[] = []; // List of emergency types
  selectedType: string = ''; // Selected type for filtering

  constructor(private emergencyService: EmergencyService) {}

  ngOnInit(): void {
    this.fetchEmergencyTypes();
  }

  fetchEmergencyTypes(): void {
    // Fetch the list of emergency types from the API
    this.emergencyService.getEmergencyTypes().subscribe(types => {
      this.emergencyTypes = types;
    });
  }

  onFilterChange(event: Event): void {
    const target = event.target as HTMLSelectElement;
    this.selectedType = target.value;
    console.log('Selected Emergency Type:', this.selectedType);
  }
}