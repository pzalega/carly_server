using MediatR;

namespace Carly.App.Commands
{
    public sealed record DeleteVehicleCommand(int Id) : IRequest;
}
