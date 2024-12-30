using Carly.Api.Requests;
using Carly.App.Commands;
using Carly.App.DTO;
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

            app.MapPost("vehicles", async (AddVehicleRequest request, IMediator _mediator) =>
            {
                var command = new AddVehicleCommand(request.Name);
                await _mediator.Send(command);

                return Results.Created();
            });

            app.MapPatch("vehicles/{vehicleId}", async (int vehicleId, VehicleDto vehicleDto, IVehicleService _vehicleService) =>
            {
                await _vehicleService.Update(vehicleId, vehicleDto);

                return Results.NoContent();

            });

            app.MapDelete("vehicles/{vehicleId}", async (int vehicleId, IVehicleService _vehiclesService) =>
            {
                await _vehiclesService.Delete(vehicleId);

                return Results.NoContent();
            });
        }
    }
}
