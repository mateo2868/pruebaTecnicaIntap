using pruebaIntap2.Infrastructure;
using pruebaIntap2.Models;

namespace pruebaIntap2.Applications
{
    public class ActividadService
    {
        private readonly IActividadRepository _repo;

        public ActividadService(IActividadRepository repo)
        {
            _repo = repo;
        }

        public async Task AgregarTiempoAsync(int actividadId, TiempoActividad nuevoTiempo)
        {
            // Obtener los tiempos actuales de la actividad
            var tiempos = await _repo.GetTiemposByActividadIdAsync(actividadId);
            int totalHoras = tiempos.Sum(t => t.Hours);

            // Validar que no se excedan las 8 horas
            if (totalHoras + nuevoTiempo.Hours > 8)
            {
                throw new InvalidOperationException("No se pueden registrar más de 8 horas en una sola actividad.");
            }

            nuevoTiempo.ActivityId = actividadId;
            await _repo.AddTiempoAsync(nuevoTiempo);
            await _repo.SaveChangesAsync();
        }

        public async Task<List<TiempoActividad>> ObtenerTiemposPorActividadAsync(int actividadId)
        {
            return await _repo.GetTiemposByActividadIdAsync(actividadId);
        }

        public async Task<Activity> AgregarActividadAsync(Activity nuevaActividad)
        {
            if (nuevaActividad == null)
                throw new ArgumentNullException(nameof(nuevaActividad));

            await _repo.AddAsync(nuevaActividad);
            await _repo.SaveChangesAsync();
            return nuevaActividad;
        }

        public async Task<List<Activity>> ObtenerActividadesPorUsuarioAsync(int usuarioId)
        {
            return await _repo.GetByUsuarioIdAsync(usuarioId);
        }

    }

}
