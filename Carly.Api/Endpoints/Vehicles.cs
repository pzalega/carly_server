using Carly.Api.Requests;
using Carly.App.Features.Vehicles.AddNew;
using Carly.App.Features.Vehicles.Delete;
using Carly.App.Features.Vehicles.Update;
using Carly.App.Services;
using Carter;
using MediatR;

namespace Carly.Api.Endpoints
{
    public class Vehicles : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("vehicles", async (IVehicleService _vehiclesService) =>
            {
                return await _vehiclesService.GetAll();
            });

            app.MapGet("vehicles/{vehicleId}", async (int vehicleId, IVehicleService _vehiclesService) =>
            {
                return await _vehiclesService.Get(vehicleId);
            });

            app.MapPost("vehicles", async (AddVehicleRequest request, IMediator mediator) =>
            {
                var command = new AddVehicleCommand(request.Name);
                await mediator.Send(command);

                return Results.Created();
            });

            app.MapPatch("vehicles/{vehicleId}", async (int vehicleId, UpdateVehicleRequest request, IMediator mediator) =>
            {
                var command = new UpdateVehicleCommand(vehicleId, request.Name);

                await mediator.Send(command);

                return Results.NoContent();

            });

            app.MapDelete("vehicles/{vehicleId}", async (int vehicleId, IMediator mediator) =>
            {
                var command = new DeleteVehicleCommand(vehicleId);
                await mediator.Send(command);

                return Results.NoContent();
            });
        }
    }
}
