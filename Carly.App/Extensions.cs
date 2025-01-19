using Carly.App.DAL;
using Carly.App.DAL.Repositories;
using Carly.App.Features.Vehicles.AddNew;
using Carly.App.Repositories;
using Carly.App.Services;
using Carly.Infrastructure.MSSQL;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Carly.App
{
    public static class Extensions
    {
        public static IServiceCollection AddApp(this IServiceCollection services)
        {
            services.AddMsSql<CarlyDbContext>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IRefuelService, RefuelService>();
            services.AddScoped<IFuelTypeService, FuelTypeService>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IRefuelRepository, RefuelRepository>();
            services.AddScoped<IFuelTypeRepository, FuelTypeRepository>();
            
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(AddVehicleCommand).Assembly);
            });

            services.AddFluentValidation(new[] { typeof(AddVehicleCommand).Assembly });

            return services;

        }
    }
}
