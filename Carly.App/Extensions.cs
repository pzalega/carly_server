using Carly.App.DAL;
using Carly.App.DAL.Repositories;
using Carly.App.Features.Vehicles.AddNew;
using Carly.App.Repositories;
using Carly.App.Services;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Carly.App
{
    public static class Extensions
    {
        public static IServiceCollection AddApp(this IServiceCollection services)
        {
            services.AddDbContext<CarlyDbContext>(x => x.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Carly;Trusted_Connection=True;TrustServerCertificate=True;"));
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IRefuelService, RefuelService>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IRefuelRepository, RefuelRepository>();

            
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(AddVehicleCommand).Assembly);
            });

            services.AddFluentValidation(new[] { typeof(AddVehicleCommand).Assembly });

            return services;

        }
    }
}
