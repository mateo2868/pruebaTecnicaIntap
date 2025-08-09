// actividad.model.ts
export interface TiempoActividad {
  id: number;
  date: string;
  hours: number;
}

export interface Actividad {
  id: number;
  description: string;
  tiempos: TiempoActividad[];
}
