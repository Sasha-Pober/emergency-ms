import { Component, OnInit } from '@angular/core';
import { AnalyticsService } from '../../services/analytics/analytics.service';
import { AnalyticsResponse } from '../../models/Analytics/AnalyticsResponse';

@Component({
  selector: 'app-analytics',
  templateUrl: './analytics.component.html',
  styleUrl: './analytics.component.css'
})
export class AnalyticsComponent implements OnInit {
    rangedEmergencies: AnalyticsResponse = {
    results: [],
    bestAlternatives: []
  };
  
  constructor(private readonly analyticsService: AnalyticsService) { }

  ngOnInit(): void {
    this.fetchAnalyticsData();
  }

    fetchAnalyticsData(): void {
    this.analyticsService.getAnalyticsData().subscribe(data => {
      this.rangedEmergencies = data;
    });
  }

  isBestAlternative(regionId: number): boolean {
    return this.rangedEmergencies.bestAlternatives.some(alternative => alternative.regionId === regionId);
  }
}
