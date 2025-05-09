import { Component, OnInit } from '@angular/core';
import { EmergencyService } from '../../services/emergency/emergency.service';
import { EmergencyTypeEntity } from '../../models/types/EmergencyTypeEntity';
import { EmergencySubType } from '../../models/types/EmergencySubType';
import { AuthService } from '../../services/auth/auth.service';
import { Router } from '@angular/router';

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

  isSidebarOpen: boolean = true; 
  isLoggedIn: boolean = false;

  constructor(
    private emergencyService: EmergencyService, 
    private authService: AuthService, 
    private router: Router) {}

  ngOnInit(): void {
    this.fetchEmergencyTypes();
    this.fetchEmergencySubTypes();
    this.isLoggedIn = this.authService.isLoggedIn();
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

  toggleSidebar(): void {
    this.isSidebarOpen = !this.isSidebarOpen;
  }

  navigateToLogin(): void {
    this.router.navigate(['/login']);
  }

  logout(): void {
    this.authService.logout();
    this.isLoggedIn = false;
  }
}