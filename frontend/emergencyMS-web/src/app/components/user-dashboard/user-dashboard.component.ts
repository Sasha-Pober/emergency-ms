import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrl: './user-dashboard.component.css'
})
export class UserDashboardComponent {
  constructor(private router: Router) {}

  navigateToCreateEmergency(): void {
    this.router.navigate(['/createEmergency']); // Adjust the route if necessary
  }

  clearView(): void {
    this.router.navigate(['/dashboard']);
  }
}
