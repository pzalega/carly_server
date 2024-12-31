using Carly.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Carly.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddErrorHandling(this IServiceCollection services)
                => services.AddExceptionHandler<ProblemExceptionHandler>();

        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder app)
            => app.UseExceptionHandler();
    }
}
