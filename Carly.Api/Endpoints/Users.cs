using Carly.Api.Requests;
using Carly.App.Features.Users;
using Carter;
using MediatR;

namespace Carly.Api.Endpoints
{
    public class Users : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("users", async (RegisterCustomerRequest request, IMediator mediator) =>
            {
                var command = new RegisterCustomerCommand(request.Email, request.Password, request.Name); ;
                await mediator.Send(command);

                return Results.Created();
            });

            app.MapPost("users/login", async (LoginCustomerRequest request, IMediator mediator) =>
            {
                var command = new LoginCustomerCommand(request.Email, request.Password); ;
                await mediator.Send(command);

                return Results.Ok();
            });
        }
    }
}
