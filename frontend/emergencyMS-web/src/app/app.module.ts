import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MapComponent } from './components/map/map.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MainComponent } from './components/main/main.component';
import { LoginComponent } from './components/login/login.component';
import { FormsModule } from '@angular/forms';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { CreateEmergencyComponent } from './components/create-emergency/create-emergency.component';
import { EmergencyDetailComponent } from './components/emergency-detail/emergency-detail.component';
import { AnalyticsComponent } from './components/analytics/analytics.component';
import uk from '@angular/common/locales/uk';
import { registerLocaleData } from '@angular/common';
import { ApproveEmergenciesComponent } from './components/approve-emergencies/approve-emergencies.component';

registerLocaleData(uk);


@NgModule({
  declarations: [
    AppComponent,
    MapComponent,
    MainComponent,
    LoginComponent,
    UserDashboardComponent,
    CreateEmergencyComponent,
    EmergencyDetailComponent,
    AnalyticsComponent,
    ApproveEmergenciesComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
