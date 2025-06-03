import { Component, Input, OnInit, Type } from '@angular/core';
import { CreateEmergency } from '../../requests/CreateEmergency';
import { TypeService } from '../../services/type/type.service';
import { TypeEntity } from '../../models/types/TypeEntity';
import { EmergencyService } from '../../services/emergency/emergency.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-emergency',
  templateUrl: './create-emergency.component.html',
  styleUrl: './create-emergency.component.css'
})
export class CreateEmergencyComponent implements OnInit {
   type: string = '';

  ngOnInit(): void {
    this.type = this.route.snapshot.url[this.route.snapshot.url.length - 1].path;
    this.fetchTypes();

    console.log('Type from route:', this.type);
  }

  constructor(
    private typeService: TypeService, 
    private emergencyService: EmergencyService, 
    private route: ActivatedRoute,
    private router: Router) { }

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
      regionId: 0,
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
    if (this.type === 'create') {
      this.emergencyService.createEmergency(this.emergency).subscribe(
        () => console.log('Emergency created successfully'),
        (error) => console.error('Error creating emergency:', error)
      );
    } else if (this.type === 'suggest') {
      this.emergencyService.suggestEmergency(this.emergency).subscribe(
        () => {
          window.alert('Новину про надзвичайну ситуацію успішно надіслано на розгляд!');
          this.router.navigate(['/main']);
        },
        (error) => console.error('Error suggesting emergency:', error)
      );
    }
    this.clearForm();
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
        regionId: 0,
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

