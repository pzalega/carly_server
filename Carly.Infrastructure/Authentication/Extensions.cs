using Carly.Shared.Abstractions.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Carly.Infrastructure.Authentication
{
    internal static class Extensions
    {
        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            var options = services.GetOptions<FirebaseOptions>("Firebase");
            services.AddSingleton(options);

            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            services.AddHttpClient<IJwtProvider, JwtProvider>(httpClient =>
            {
                //TODO get from configuration
                httpClient.BaseAddress = new Uri("https://identitytoolkit.googleapis.com");
            });

            return services;
        }
    }
}
