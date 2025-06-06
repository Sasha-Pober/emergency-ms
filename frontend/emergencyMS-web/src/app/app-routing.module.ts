import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { MainComponent } from './components/main/main.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { AuthGuard } from './guards/auth.guard';
import { CreateEmergencyComponent } from './components/create-emergency/create-emergency.component';
import { EmergencyDetailComponent } from './components/emergency-detail/emergency-detail.component';
import { AnalyticsComponent } from './components/analytics/analytics.component';
import { ApproveEmergenciesComponent } from './components/approve-emergencies/approve-emergencies.component';

const routes: Routes = [
  { path: 'main', component: MainComponent,},
  { path: 'emergency/suggest', component: CreateEmergencyComponent },
  { path: 'emergency/:id', component: EmergencyDetailComponent },
  { path: 'analytics', component: AnalyticsComponent },
  { path: 'login', component: LoginComponent, }, 
  {path: 'dashboard', component: UserDashboardComponent, children: 
    [
      {path: 'emergency/create', component: CreateEmergencyComponent},
      {path: 'approveEmergency', component: ApproveEmergenciesComponent}
    ], canActivate: [AuthGuard]},
  { path: '**', redirectTo: 'main' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
