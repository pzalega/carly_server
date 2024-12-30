using Carly.App.Commands;
using Carly.App.Entities;
using Carly.App.Repositories;
using MediatR;

namespace Carly.App.Handlers
{
    internal sealed class AddVehicleHandler : IRequestHandler<AddVehicleCommand>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public AddVehicleHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            var existingCar = await _vehicleRepository.Get(request.Name);
            if (existingCar is not null)
            {
                throw new ArgumentException("Car with that name already registered");
            }

            await _vehicleRepository.Add(
                new Vehicle { Name = request.Name });

        }
    }
}
