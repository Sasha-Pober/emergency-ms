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

  type: string = '';
  emergencyId: number = 0;

  public get dateString(): string {
    let dateToShow : Date = new Date(this.emergency.accidentDate);
    dateToShow.setHours(this.emergency.accidentDate.getHours() + 3);

    return dateToShow.toISOString().split('T')[0];
  }

  public set dateString(value: string) {
    this.emergency.accidentDate = new Date(value);
  }


  ngOnInit(): void {
    this.type = this.route.snapshot.url[this.route.snapshot.url.length - 1].path;

    this.route.queryParams.subscribe(params => {
      if (Object.keys(params).length > 0) {

        if (params['id']) {
          this.emergencyId = params['id'] as number;
        }
      }
    });

    if (this.type === 'edit') {

      this.emergencyService.getEmergencyById(this.emergencyId).subscribe(emergency => {
        this.emergency = {
          title: emergency.title,
          description: emergency.description,
          emergencyType: emergency.emergencyType!,
          emergencySubType: emergency.emergencySubType!,
          accidentDate: new Date(emergency.accidentDate),
          severity: emergency.severity,
          casualties: emergency.casualties,
          injured: emergency.injured,
          economicLoss: emergency.economicLoss,
          duration: emergency.duration,
          location: {
            name: emergency.location.name,
            regionId: emergency.location.regionId!,
            latitude: emergency.location.latitude,
            longitude: emergency.location.longitude
          },
          source: {
            name: emergency.source.name,
            url: emergency.source.url!,
            sourceTypeId: emergency.source.sourceTypeId!
          },
          street: {
            streetName: emergency.street.streetName,
            houseNr: emergency.street.houseNr
          },
          imagesEntities: emergency.images!,
          images: [],
          imagesToDelete: [],
        }
      });

    }
    this.fetchTypes();
  }

  constructor(
    private typeService: TypeService,
    private emergencyService: EmergencyService,
    private route: ActivatedRoute,
    private router: Router) { }

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
    if (this.type === 'create') {
      this.emergencyService.createEmergency(this.emergency).subscribe(
        () => window.alert('Новину про надзвичайну ситуацію успішно додано!'),
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
    else if (this.type === 'edit') {
      this.emergencyService.updateEmergency(this.emergency, this.emergencyId).subscribe(
        () =>{
          window.alert('Новину про надзвичайну ситуацію успішно оновлено!');
          this.router.navigate(['dashboard/emergency/approve'])
        },
      );
    }
    this.clearForm();
  }


  deleteImage(name: string): void {
    this.emergency.imagesToDelete?.push(name);

    this.emergency.imagesEntities = this.emergency.imagesEntities?.filter(image => image.fileName !== name);

    console.log('Images to delete:', this.emergency.imagesToDelete!);
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

