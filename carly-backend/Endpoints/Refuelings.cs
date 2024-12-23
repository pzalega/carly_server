using Carly.App.DTO;
using Carly.App.Services;
using Carter;

namespace Carly.Api.Endpoints
{
    public class Refuelings : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("refuelings", async (IRefuelService _refuelService) =>
            {
                return await _refuelService.GetAll();
            });

            app.MapPost("refuelings", async (AddRefuelDto addRefuelDto, IRefuelService _refuelServive) =>
            {
                await _refuelServive.RefuelVehicle(addRefuelDto.VehicleId, addRefuelDto);

                return Results.Created();
            });
        }
    }
}
