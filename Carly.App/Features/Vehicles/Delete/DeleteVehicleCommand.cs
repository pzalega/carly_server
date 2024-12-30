using MediatR;

namespace Carly.App.Features.Vehicles.Delete
{
    public sealed record DeleteVehicleCommand(int Id) : IRequest;
}
