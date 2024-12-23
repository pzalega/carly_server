using Carly.App.DAL;
using Carly.App.DAL.Repositories;
using Carly.App.Repositories;
using Carly.App.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

            return services;

        }
    }
}
