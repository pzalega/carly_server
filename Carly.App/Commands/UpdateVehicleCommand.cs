using MediatR;

namespace Carly.App.Commands
{
    public sealed record UpdateVehicleCommand (int Id, string Name) : IRequest;
}
