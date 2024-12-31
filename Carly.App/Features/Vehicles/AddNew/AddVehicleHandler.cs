using Carly.App.Entities;
using Carly.App.Exceptions;
using Carly.App.Repositories;
using MediatR;

namespace Carly.App.Features.Vehicles.AddNew
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
                throw new CarWithThatNameAlreadyExistsException(existingCar.Name);
            }

            await _vehicleRepository.Add(
                new Vehicle { Name = request.Name });

        }
    }
}
