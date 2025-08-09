namespace pruebaIntap2.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public List<TiempoActividad> Tiempos { get; set; } = new();
    }
}