using Carly.App.DAL.Repositories;
using Carly.App.DTO;
using Carly.App.Entities;
using Carly.App.Repositories;

namespace Carly.App.Services
{
    internal sealed class RefuelService : IRefuelService
    {
        private readonly IVehicleRepository _carRepository;
        private readonly IRefuelRepository _refuelRepository;

        public RefuelService(IVehicleRepository carRepository, IRefuelRepository refuelRepository)
        {
            _carRepository = carRepository;
            _refuelRepository = refuelRepository;
        }

        public async Task RefuelVehicle(Guid carId, AddRefuelDto fillUpDto)
        {
            var existingCar = await _carRepository.Get(carId);
            if (existingCar is null)
            {
                throw new ArgumentException("Car does not exist");
            }

            existingCar.Refuels.Add(new Refuel
            {
                VehicleId = carId,
                CreatedAt = DateTime.UtcNow,
                RefuelDate = DateOnly.FromDateTime(fillUpDto.FillUpDate),
                FuelLitres = fillUpDto.FuelLitres,
                LitrePrice = fillUpDto.LitrePrice,
                RefuelPrice = fillUpDto.FuelLitres * fillUpDto.LitrePrice,
                Id = Guid.NewGuid(),
            });

            await _carRepository.Update(existingCar);
        }

        public async Task<IEnumerable<RefuelDto>> GetAll()
        {
            var refuels = await _refuelRepository.Browse();

            return refuels.Select(x => new RefuelDto
            {
                CreatedAt = x.CreatedAt,
                FillUpDate = x.RefuelDate.ToDateTime(TimeOnly.MaxValue),
                FillUpPrice = x.RefuelPrice,
                Id = x.Id,
                FuelLitres = x.FuelLitres,
                LitrePrice = x.LitrePrice,
                VehicleId = x.VehicleId,
                VehicleName = x.Vehicle.Name
            });

        }
    }
}
