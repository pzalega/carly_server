using MediatR;

namespace Carly.App.Features.Vehicles.AddNew
{
    public sealed record AddVehicleCommand(string Name) : IRequest;
}
