import { Component, OnInit } from '@angular/core';
import { EmergencyService } from '../../services/emergency/emergency.service';
import { Emergency } from '../../models/Emergency';
import { Router } from '@angular/router';

@Component({
  selector: 'app-approve-emergencies',
  templateUrl: './approve-emergencies.component.html',
  styleUrls: ['./approve-emergencies.component.css']
})
export class ApproveEmergenciesComponent implements OnInit {
  unapprovedEmergencies: Emergency[] = [];

  constructor(private emergencyService: EmergencyService, private router: Router) { }

  ngOnInit(): void {
    this.fetchUnapprovedEmergencies();
  }

  fetchUnapprovedEmergencies(): void {
    this.emergencyService.getUnapprovedEmergencies().subscribe(
      (data: Emergency[]) => {
        this.unapprovedEmergencies = data;

        console.log('Unapproved Emergencies:', this.unapprovedEmergencies);
      }
    );
  }

  approveEmergency(emergencyId: number): void {
    this.emergencyService.approveEmergency(emergencyId).subscribe(
      () => {
        // Remove the approved emergency from the list
        this.unapprovedEmergencies = this.unapprovedEmergencies.filter(e => e.id !== emergencyId);
      },
      (error) => {
        console.error('Error approving emergency:', error);
      }
    );
  }

  deleteEmergency(emergencyId: number): void {
    this.emergencyService.deleteEmergency(emergencyId).subscribe(
      () => {
        // Remove the deleted emergency from the list
        this.unapprovedEmergencies = this.unapprovedEmergencies.filter(e => e.id !== emergencyId);
      },
      (error) => {
        console.error('Error deleting emergency:', error);
      }
    );
  }

  editEmergency(emergencyId: number): void {
      this.router.navigate(['/dashboard/emergency/edit'], { queryParams: { id: emergencyId } });
    }
}
