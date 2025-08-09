import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Login } from '../../interfaces/login';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html'
})
export class LoginComponent {
  dto: Login = { username: '', passwordHash: '' };
  errorMessage = '';

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    this.authService.login(this.dto).subscribe({
      next: res => {
        console.log('Login exitoso', res);
        localStorage.setItem('login', JSON.stringify(res) )

        this.router.navigate(['/actividad']);

      },
      error: err => {
        this.errorMessage = err.error;
      }
    });
  }
}
