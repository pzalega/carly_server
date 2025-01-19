using Carly.App.Services;
using Carter;

namespace Carly.Api.Endpoints
{
    public class FuelTypes : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("fuelTypes", async (IFuelTypeService _fuelTypeService) =>
            {
                return await _fuelTypeService.GetAll();
            });
        }
    }
}
