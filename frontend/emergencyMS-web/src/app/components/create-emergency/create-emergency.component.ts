import { Component, OnInit, Type } from '@angular/core';
import { CreateEmergency } from '../../requests/CreateEmergency';
import { TypeService } from '../../services/type/type.service';
import { TypeEntity } from '../../models/types/TypeEntity';
import { EmergencyService } from '../../services/emergency/emergency.service';

@Component({
  selector: 'app-create-emergency',
  templateUrl: './create-emergency.component.html',
  styleUrl: './create-emergency.component.css'
})
export class CreateEmergencyComponent implements OnInit {

  ngOnInit(): void {
    this.fetchTypes();
  }

  constructor(private typeService: TypeService, private emergencyService: EmergencyService) { }

  emergency: CreateEmergency = {
    title: '',
    description: '',
    emergencyType: 0,
    accidentDate: new Date(),
    severity: 0,
    casualties: 0,
    injured: 0,
    economicLoss: 0,
    duration: 0,
    location: {
      name: '',
      regionTypeId: 0,
      latitude: 0,
      longitude: 0
    },
    source: {
      name: '',
      url: '',
      sourceTypeId: 0,
    },
    street: {
      streetName: '',
      houseNr: 0,
    },
    images: []
  };

  selectedFiles: File[] = [];
  types: TypeEntity = {
    types: [],
    subTypes: [],
    regionTypes: [],
    sourceTypes: []
  };

  fetchTypes(): void {
    this.typeService.getAllTypes().subscribe(types => {
      this.types.types = types.types;
      this.types.subTypes = types.subTypes;
      this.types.regionTypes = types.regionTypes;
      this.types.sourceTypes = types.sourceTypes;
    });
  }

  onFileSelected(event: any): void {
    this.emergency.images = Array.from(event.target.files);
  }

  onSubmit(): void {
    console.log('Emergency Data:', this.emergency);
    console.log('Selected Files:', this.emergency.images);
    this.emergencyService.createEmergency(this.emergency).subscribe({
      next: (response) => {
        console.log('Emergency created successfully:', response);
        alert('Emergency created successfully');
        this.clearForm();
      },
      error: (error) => {
        console.error('Error creating emergency:', error);
      }
    });
  }

  private clearForm(): void {
    this.emergency = {
      title: '',
      description: '',
      emergencyType: 0,
      accidentDate: new Date(),
      severity: 0,
      casualties: 0,
      injured: 0,
      economicLoss: 0,
      duration: 0,
      location: {
        name: '',
        regionTypeId: 0,
        latitude: 0,
        longitude: 0
      },
      source: {
        name: '',
        url: '',
        sourceTypeId: 0,
      },
      street: {
        streetName: '',
        houseNr: 0,
      },
      images: []
    };
    this.selectedFiles = [];
  }

}

