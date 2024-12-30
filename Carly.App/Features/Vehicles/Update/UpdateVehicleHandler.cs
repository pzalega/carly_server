using Carly.App.Repositories;
using Carly.App.Services;
using MediatR;

namespace Carly.App.Features.Vehicles.Update
{
    internal sealed class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommand>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public UpdateVehicleHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var existingVehicle = await _vehicleRepository.Get(request.Id);
            if (existingVehicle is null)
            {
                throw new ArgumentException("Car with that id does not exists");
            }

            existingVehicle.Name = request.Name;
            await _vehicleRepository.Update(existingVehicle);
        }
    }
}
