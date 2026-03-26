import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { MedicsComponent } from './pages/medics/medics';
import { Pacients } from './pages/pacients/pacients';
import { Appointments } from './pages/appointments/appointments';
import { Login } from './pages/login/login';
import { Register } from './pages/register/register';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full'},
  { path: 'home', component: Home },
  { path: 'medics', component: MedicsComponent },
  { path: 'appointments', component: Appointments },
  { path: 'pacients', component: Pacients},
  { path: 'login', component: Login },
  { path: 'register', component: Register },
  { path: '**', redirectTo: '' } // Redirect pentru rute inexistente
];