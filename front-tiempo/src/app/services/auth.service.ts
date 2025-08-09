import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../interfaces/login';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'https://localhost:7180/api/auth'; // Ajusta según tu backend

  constructor(private http: HttpClient) {}

  login(dto: Login): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, dto);
  }
}
