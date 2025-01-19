using Carly.Infrastructure.Authentication;
using Carly.Infrastructure.Exceptions;
using Carly.Infrastructure.Firebase;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carly.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddExceptionHandler<ProblemExceptionHandler>();

            services.AddAuth();
            services.AddFirebaseServices();

            return services;

        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
            => app.UseExceptionHandler();


        public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
        {
            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            return configuration.GetOptions<T>(sectionName);
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
        {
            var options = new T();
            configuration.GetSection(sectionName).Bind(options);
            return options;
        }


    }
}
