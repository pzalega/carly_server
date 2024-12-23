using Carly.App.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carly.App.DAL
{
    internal sealed class CarlyDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Refuel> Refuels { get; set; }

        public CarlyDbContext()
        {
            
        }

        public CarlyDbContext(DbContextOptions<CarlyDbContext> options)
            : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("carly");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
