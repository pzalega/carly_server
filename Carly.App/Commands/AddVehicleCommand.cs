using MediatR;

namespace Carly.App.Commands
{
    public sealed record AddVehicleCommand(string Name) : IRequest;
}
