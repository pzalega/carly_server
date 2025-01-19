using Carly.App.DTO;
using Carly.App.Repositories;

namespace Carly.App.Services
{
    internal sealed class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleDto?> Get(int id)
        {
            var existingVehicle = await _vehicleRepository.Get(id);

            if(existingVehicle is null)
            {
                return null;
            }

            return new VehicleDto { Name = existingVehicle.Name, Id = existingVehicle.Id, CreatedAt = existingVehicle.CreatedAt };
        }

        public async Task<IEnumerable<VehicleDto>> GetAll()
        {
            var vehicles = await _vehicleRepository.Browse();

            if(vehicles is null)
            {
                return null;
            }

            return vehicles.Select(x=>new VehicleDto { Name = x.Name, Id = x.Id, CreatedAt = x.CreatedAt }).ToList();
        }
    }
}
