import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Actividad, TiempoActividad } from '../interfaces/actividad';
import { Observable } from 'rxjs';
import { Login } from '../interfaces/login';

@Injectable({ providedIn: 'root' })
export class ActividadService {
  private apiUrl = 'https://localhost:7180/api/actividades';
  loginUser;

  constructor(private http: HttpClient) {
    if (typeof window !== 'undefined') {
      this.loginUser = JSON.parse(localStorage.getItem('login') as string) as any
    }
  }

  obtenerActividades(): Observable<Actividad[]> {
    return this.http.get<Actividad[]>(`${this.apiUrl}/usuario/${this.loginUser.id}`);
  }

  crearActividad(descripcion: string): Observable<Actividad> {
    return this.http.post<Actividad>(`${this.apiUrl}/actividad`, { descripcion, userId: this.loginUser.id });
  }

  agregarTiempo(idActividad: number, tiempo: TiempoActividad): Observable<any> {
    return this.http.post(`${this.apiUrl}/${idActividad}/tiempos`, tiempo);
  }
}
