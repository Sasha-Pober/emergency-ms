import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { MainComponent } from './components/main/main.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { AuthGuard } from './guards/auth.guard';
import { CreateEmergencyComponent } from './components/create-emergency/create-emergency.component';

const routes: Routes = [
  { path: 'main', component: MainComponent },
  { path: 'login', component: LoginComponent, }, 
  {path: 'dashboard', component: UserDashboardComponent, children: 
    [
      {path: 'createEmergency', component: CreateEmergencyComponent}
    ], canActivate: [AuthGuard]},
  { path: '**', redirectTo: 'main' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
