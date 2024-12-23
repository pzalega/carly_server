using Carly.App.DTO;
using Carly.App.Services;
using Carter;

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

            app.MapGet("vehicles/{vehicleId}", async (Guid vehicleId, IVehicleService _vehiclesService) =>
            {
                return await _vehiclesService.Get(vehicleId);
            });

            app.MapPost("vehicles", async (VehicleDto vehicle, IVehicleService _vehicleService) =>
            {
                await _vehicleService.Add(vehicle);
                return Results.Created();
            });

            app.MapPatch("vehicles/{vehicleId}", async (Guid vehicleId, VehicleDto vehicleDto, IVehicleService _vehicleService) =>
            {
                await _vehicleService.Update(vehicleId, vehicleDto);

                return Results.NoContent();

            });

            app.MapDelete("vehicles/{vehicleId}", async (Guid vehicleId, IVehicleService _vehiclesService) =>
            {
                await _vehiclesService.Delete(vehicleId);

                return Results.NoContent();
            });
        }
    }
}
