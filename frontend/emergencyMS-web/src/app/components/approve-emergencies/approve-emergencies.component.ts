import { Component, OnInit } from '@angular/core';
import { EmergencyService } from '../../services/emergency/emergency.service';
import { Emergency } from '../../models/Emergency';

@Component({
  selector: 'app-approve-emergencies',
  templateUrl: './approve-emergencies.component.html',
  styleUrls: ['./approve-emergencies.component.css']
})
export class ApproveEmergenciesComponent implements OnInit {
  unapprovedEmergencies: Emergency[] = [];

  constructor(private emergencyService: EmergencyService) {}

  ngOnInit(): void {
    this.fetchUnapprovedEmergencies();
  }

  fetchUnapprovedEmergencies(): void {
    this.emergencyService.getUnapprovedEmergencies().subscribe(
      (data: Emergency[]) => {
        this.unapprovedEmergencies = data;
      }
    );
  }
}
