using pruebaIntap2.Models;

namespace pruebaIntap2.Infrastructure
{
    public interface IActividadRepository
    {
        Task<List<Activity>> GetByUsuarioIdAsync(int usuarioId);
        Task<Activity?> GetByIdAsync(int id);
        Task AddAsync(Activity actividad);
        Task AddTiempoAsync(TiempoActividad tiempo);
        Task<List<TiempoActividad>> GetTiemposByActividadIdAsync(int actividadId);
        Task SaveChangesAsync();
    }
}
