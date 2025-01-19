using MediatR;

namespace Carly.App.Features.Users
{
    public record RegisterCustomerCommand(string Email, string Password, string Name) : IRequest;

}
