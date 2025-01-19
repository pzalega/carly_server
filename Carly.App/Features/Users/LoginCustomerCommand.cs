using MediatR;

namespace Carly.App.Features.Users
{
    public record LoginCustomerCommand(string Email, string Password) : IRequest;
}
