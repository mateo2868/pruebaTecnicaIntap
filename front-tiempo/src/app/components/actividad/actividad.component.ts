import { Component } from '@angular/core';
import { ActividadService } from '../../services/actividad.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { Actividad } from '../../interfaces/actividad';

@Component({
  selector: 'app-actividad',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './actividad.component.html',
  styleUrl: './actividad.component.css'
})
export class ActividadComponent {

  actividades: Actividad[] = [];

  constructor(private actividadService: ActividadService, public router: Router) {}

  ngOnInit(): void {
    this.actividadService.obtenerActividades().subscribe(data => {
      this.actividades = data;
    });
  }

  abrirFormularioTiempo(idActividad: number) {
    this.router.navigate(['crear-tiempo', idActividad]);
  }
}
