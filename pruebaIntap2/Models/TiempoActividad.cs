﻿namespace pruebaIntap2.Models
{
    public class TiempoActividad
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public int ActivityId { get; set; }
    }
}
