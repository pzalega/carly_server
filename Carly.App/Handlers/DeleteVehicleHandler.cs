using Carly.App.Commands;
using Carly.App.Repositories;
using MediatR;

namespace Carly.App.Handlers
{
    internal sealed class DeleteVehicleHandler : IRequestHandler<DeleteVehicleCommand>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public DeleteVehicleHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            var existingVehicle = await _vehicleRepository.Get(request.Id);
            if (existingVehicle is null)
            {
                throw new ArgumentException("Car with that id does not exists");
            }

            // TODO policy canDelete

            await _vehicleRepository.Delete(existingVehicle);
        }
    }
}
