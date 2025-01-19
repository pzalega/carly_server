using Carly.App.Entities;
using Carly.App.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Carly.App.DAL.Repositories
{
    internal sealed class FuelTypeRepository : IFuelTypeRepository
    {
        private readonly DbSet<FuelType> _fuelTypes;

        public FuelTypeRepository(CarlyDbContext context)
        {
            _fuelTypes = context.FuelTypes;
        }

        public async Task<IReadOnlyList<FuelType>> Browse() => await _fuelTypes.AsNoTracking().ToListAsync();
    }
}
