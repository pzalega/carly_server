using Carly.App.Entities;
using Carly.App.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Carly.App.DAL.Repositories
{
    internal sealed class RefuelRepository : IRefuelRepository
    {
        private readonly CarlyDbContext _context;
        private readonly DbSet<Refuel> _refuels;

        public RefuelRepository(CarlyDbContext context)
        {
            _context = context;
            _refuels = context.Refuels;
        }

        public async Task<IReadOnlyList<Refuel>> Browse()
        {
            return await _refuels.Include(c=>c.Vehicle).ToListAsync();
        }
    }
}
