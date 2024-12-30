using Carly.App.DTO;
using Carly.App.Entities;
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

        public async Task Add(VehicleDto vehicle)
        {
            var existingCar = await _vehicleRepository.Get(vehicle.Name);
            if (existingCar is not null)
            {
                throw new ArgumentException("Car with that name already registered");
            }

            await _vehicleRepository.Add(
                new Vehicle { Name = vehicle.Name });
        }

        public async Task Delete(int id)
        {
            var existingVehicle = await _vehicleRepository.Get(id);
            if (existingVehicle is null)
            {
                throw new ArgumentException("Car with that id does not exists");
            }

            // TODO policy canDelete

            await _vehicleRepository.Delete(existingVehicle);
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

        public async Task Update(int id, VehicleDto vehicle)
        {
            var existingVehicle = await _vehicleRepository.Get(id);
            if (existingVehicle is null)
            {
                throw new ArgumentException("Car with that id does not exists");
            }

            existingVehicle.Name = vehicle.Name;
            await _vehicleRepository.Update(existingVehicle);
        }
    }
}
