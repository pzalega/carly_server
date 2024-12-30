using MediatR;

namespace Carly.App.Features.Vehicles.Update
{
    public sealed record UpdateVehicleCommand(int Id, string Name) : IRequest;
}
