using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.DependencyInjection;

namespace Carly.Infrastructure.Firebase
{
    internal static class Extensions
    {
        public static IServiceCollection AddFirebaseServices(this IServiceCollection services)
        {
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile("firebase.json")
            });

            return services;
        }
    }
}
