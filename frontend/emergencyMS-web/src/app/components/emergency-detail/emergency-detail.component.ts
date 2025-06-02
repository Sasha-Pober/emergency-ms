import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmergencyService } from '../../services/emergency/emergency.service';
import { EmergencyWithImages } from '../../models/EmergencyWithImages';
import { TypeService } from '../../services/type/type.service';
import { EmergencyTypeEntity } from '../../models/types/EmergencyTypeEntity';
import { EmergencySubType } from '../../models/types/EmergencySubType';

@Component({
  selector: 'app-emergency-detail',
  templateUrl: './emergency-detail.component.html',
  styleUrls: ['./emergency-detail.component.css']
})
export class EmergencyDetailComponent implements OnInit {
  emergencyId: number = 0;
  emergency: EmergencyWithImages = null!;

  emergencyTypes: EmergencyTypeEntity[] = [];
  emergencySubTypes: EmergencySubType[] = [];

  emergencyTypeName: string = '';
  emergencySubTypeName: string = '';

  constructor(
    private route: ActivatedRoute,
    private emergencyService: EmergencyService,
    private readonly typeService: TypeService) { }

  ngOnInit(): void {
    // Get the emergency ID from the route
    this.emergencyId = +this.route.snapshot.paramMap.get('id')!;
    this.fetchTypesAndSubtypes();
    if (this.emergencyId) {
      this.fetchEmergencyDetails(this.emergencyId);
    }
  }

  fetchEmergencyDetails(id: number): void {
    this.emergencyService.getEmergencyById(id).subscribe(
      (data: EmergencyWithImages) => {
        this.emergency = data;
        this.emergencyTypeName = this.getEmergencyTypeName(this.emergency.emergencyType);
        this.emergencySubTypeName = this.getEmergencySubTypeName(this.emergency.emergencySubType);
      }
    );
  }

  fetchTypesAndSubtypes(): void {
    this.typeService.getEmergencyTypes().subscribe(
      (types) => {
        this.emergencyTypes = types;
      }
    );

    this.typeService.getEmergencySubTypes().subscribe(
      (types) => {
        this.emergencySubTypes = types;
      }
    );
  }

  getEmergencyTypeName(typeId: number | undefined): string {
    let type = this.emergencyTypes.find(t => t.id === typeId);
    return type ? type.name : 'Unknown Type';
  }

  getEmergencySubTypeName(subTypeId: number | undefined): string {
    let subType = this.emergencySubTypes.find(t => t.id === subTypeId);
    return subType ? subType.name : 'Unknown SubType';
  }
}