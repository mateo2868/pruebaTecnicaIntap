import { Component, Input } from '@angular/core';
import { ActividadService } from '../../../services/actividad.service';
import { ActivatedRoute, Router } from '@angular/router';
// import { TiempoActividad } from '../actividad.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TiempoActividad } from '../../../interfaces/actividad';


@Component({
  selector: 'app-crear-tiempo',
  imports: [CommonModule, FormsModule],
  templateUrl: './crear-tiempo.component.html',
  styleUrl: './crear-tiempo.component.css'
})
export class CrearTiempoComponent {
  idActividad!: number;
  fecha: string = '';
  horas: number = 1;
  errorMessage: string = '';

  constructor(private actividadService: ActividadService, private route: ActivatedRoute) {
    this.route.paramMap.subscribe(res => {
      console.log(res.get('id'));

      this.idActividad = res.get('id') as any;
    })
  }

  agregarTiempo() {
    const tiempo = { date: this.fecha, hours: this.horas } as TiempoActividad;
    this.actividadService.agregarTiempo(this.idActividad, tiempo).subscribe({
      next: () => {
        this.errorMessage = '';
        alert('Tiempo agregado correctamente');
      },
      error: err => {
        console.log(err);

        this.errorMessage = err.error || 'Error al agregar tiempo';
        alert(this.errorMessage);

      }
    });
  }
}
