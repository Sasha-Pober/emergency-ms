import { Component, OnInit } from '@angular/core';
import { EmergencyService } from '../../services/emergency/emergency.service';
import { EmergencyTypeEntity } from '../../models/EmergencyTypeEntity';
import { EmergencySubType } from '../../models/EmergencySubType';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  emergencyTypes: EmergencyTypeEntity[] = []; // List of emergency types
  emergencySubTypes: EmergencySubType[] = []; // List of emergency types
  selectedType: number = 0; // Selected type for filtering
  selectedSubType: number = 0; // Selected subtype for filtering

  constructor(private emergencyService: EmergencyService) {}

  ngOnInit(): void {
    this.fetchEmergencyTypes();
    this.fetchEmergencySubTypes(); // Fetch emergency subtypes on initialization
  }

  fetchEmergencyTypes(): void {
    // Fetch the list of emergency types from the API
    this.emergencyService.getEmergencyTypes().subscribe(types => {
      this.emergencyTypes = types;
    });
  }

  fetchEmergencySubTypes(): void {
    // Fetch the list of emergency types from the API
    this.emergencyService.getEmergencySubTypes().subscribe(types => {
      this.emergencySubTypes = types;
    });
  }

  onTypeChange(event: Event): void {
    const target = event.target as HTMLSelectElement;
    this.selectedType = parseInt(target.value);

    // // Filter subtypes based on the selected type
    // if (this.selectedType === 0) {
    //   this.emergencySubTypes = this.emergencySubTypes; // Show all subtypes if no type is selected
    // } else {
    //   this.emergencySubTypes = this.emergencySubTypes.filter(
    //     subType => subType.id === this.selectedSubType
    //   );
    // }

    // // Reset the selected subtype when the type changes
    // this.selectedSubType = 0;
  }

  onSubTypeChange(event: Event): void {
    const target = event.target as HTMLSelectElement;
    this.selectedSubType = parseInt(target.value);
  }
}