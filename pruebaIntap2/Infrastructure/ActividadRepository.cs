using Microsoft.EntityFrameworkCore;
using pruebaIntap2.Models;

namespace pruebaIntap2.Infrastructure
{
    public class ActividadRepository : IActividadRepository
    {
        private readonly AppDbContext _context;

        public ActividadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Activity>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Activities
                .Where(a => a.UserId == usuarioId)
                .Include(a => a.Tiempos)
                .ToListAsync();
        }

        //public async Task<Activity?> GetByIdAsync(int id)
        //{
        //    return await _context.Actividades
        //        .Include(a => a.Tiempos)
        //        .FirstOrDefaultAsync(a => a.Id == id);
        //}

        public async Task AddAsync(Activity actividad)
        {
            await _context.Activities.AddAsync(actividad);
        }

        public Task<Activity?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddTiempoAsync(TiempoActividad tiempo)
        {
            await _context.ActivityTimes.AddAsync(tiempo);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<TiempoActividad>> GetTiemposByActividadIdAsync(int actividadId)
        {
            return await _context.ActivityTimes
                .Where(t => t.ActivityId == actividadId)
                .ToListAsync();
        }
    }

}
