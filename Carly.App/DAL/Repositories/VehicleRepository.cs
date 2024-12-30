using Carly.App.Entities;
using Carly.App.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Carly.App.DAL.Repositories
{
    internal sealed class VehicleRepository : IVehicleRepository
    {
        private readonly CarlyDbContext _context;
        private readonly DbSet<Vehicle> _vehicles;

        public VehicleRepository(CarlyDbContext context)
        {
            _context = context;
            _vehicles = context.Vehicles;
        }

        public async Task Add(Vehicle car)
        {
            await _vehicles.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Vehicle>> Browse() => await _vehicles.ToListAsync();

        public async Task Delete(Vehicle car)
        {
            _vehicles.Remove(car);
            await _context.SaveChangesAsync();
        }

        public Task<Vehicle?> Get(int id) => _vehicles.SingleOrDefaultAsync(car => car.Id == id);

        public Task<Vehicle?> Get(string name) => _vehicles.SingleOrDefaultAsync(x => x.Name == name);

        public async Task Update(Vehicle car)
        {
            _vehicles.Update(car);
            await _context.SaveChangesAsync();
        }
    }
}
