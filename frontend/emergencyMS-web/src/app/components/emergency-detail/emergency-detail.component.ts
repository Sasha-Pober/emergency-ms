import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmergencyService } from '../../services/emergency/emergency.service';
import { EmergencyWithImages } from '../../models/EmergencyWithImages';

@Component({
  selector: 'app-emergency-detail',
  templateUrl: './emergency-detail.component.html',
  styleUrls: ['./emergency-detail.component.css']
})
export class EmergencyDetailComponent implements OnInit {
  emergencyId: number = 0;
  emergency: EmergencyWithImages =null!;

  constructor(private route: ActivatedRoute, private emergencyService: EmergencyService) {}

  ngOnInit(): void {
    // Get the emergency ID from the route
    this.emergencyId = +this.route.snapshot.paramMap.get('id')!;
    if (this.emergencyId) {
      this.fetchEmergencyDetails(this.emergencyId);
    }
  }

  fetchEmergencyDetails(id: number): void {
    this.emergencyService.getEmergencyById(id).subscribe(
      (data: EmergencyWithImages) => {
        this.emergency = data;
        console.log(data.images);
      },
      (error) => {
        console.error('Error fetching emergency details:', error);
      }
    );
  }
}