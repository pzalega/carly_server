using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Carly.Infrastructure.MSSQL
{
    public static class Extensions
    {
        public static IServiceCollection AddMsSql<T>(this IServiceCollection services) where T : DbContext
        {
            var options = services.GetOptions<MsSqlOptions>("mssql");
            services.AddDbContext<T>(x => x.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
