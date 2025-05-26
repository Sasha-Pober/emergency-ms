import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-emergency-detail',
  templateUrl: './emergency-detail.component.html',
  styleUrl: './emergency-detail.component.css'
})
export class EmergencyDetailComponent {
  emergencyId: number = 0;

  constructor(private route: ActivatedRoute) {
    this.emergencyId = this.route.snapshot.params['id'];
  }
}
