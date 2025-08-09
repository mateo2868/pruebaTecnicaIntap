import { Component } from '@angular/core';
import { ActividadService } from '../../../services/actividad.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-crear-actividad',
  imports: [CommonModule, FormsModule],
  templateUrl: './crear-actividad.component.html',
  styleUrl: './crear-actividad.component.css'
})
export class CrearActividadComponent {
  descripcion: string = '';

  constructor(private actividadService: ActividadService, private router: Router) {}

  crearActividad() {
    this.actividadService.crearActividad(this.descripcion).subscribe(() => {
      console.log('actividad');

      this.router.navigate(['/actividad']);
    });
  }
}
