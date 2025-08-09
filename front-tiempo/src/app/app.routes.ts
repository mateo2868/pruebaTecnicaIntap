import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ActividadComponent } from './components/actividad/actividad.component';
import { CrearActividadComponent } from './components/actividad/crear-actividad/crear-actividad.component';
import { CrearTiempoComponent } from './components/actividad/crear-tiempo/crear-tiempo.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'actividad', component: ActividadComponent },
  { path: 'crear-actividad', component: CrearActividadComponent },
  { path: 'crear-tiempo/:id', component: CrearTiempoComponent },

  { path: '', redirectTo: 'login', pathMatch: 'full' }
];
