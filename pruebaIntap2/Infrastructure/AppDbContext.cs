using Microsoft.EntityFrameworkCore;
using pruebaIntap2.Models;

namespace pruebaIntap2.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<TiempoActividad> ActivityTimes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Username).IsUnique();
        }
    }
}
