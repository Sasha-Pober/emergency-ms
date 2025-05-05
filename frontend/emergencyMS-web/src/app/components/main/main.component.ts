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
  emergencyTypes: EmergencyTypeEntity[] = [];
  emergencySubTypes: EmergencySubType[] = []; 
  selectedType: number = 0;
  selectedSubType: number = 0;

  constructor(private emergencyService: EmergencyService) {}

  ngOnInit(): void {
    this.fetchEmergencyTypes();
    this.fetchEmergencySubTypes();
  }

  fetchEmergencyTypes(): void {
    this.emergencyService.getEmergencyTypes().subscribe(types => {
      this.emergencyTypes = types;
    });
  }

  fetchEmergencySubTypes(): void {
    this.emergencyService.getEmergencySubTypes().subscribe(types => {
      this.emergencySubTypes = types;
    });
  }

  onTypeChange(event: Event): void {
    const target = event.target as HTMLSelectElement;
    this.selectedType = parseInt(target.value);
  }

  onSubTypeChange(event: Event): void {
    const target = event.target as HTMLSelectElement;
    this.selectedSubType = parseInt(target.value);
  }
}