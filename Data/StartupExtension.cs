using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SW.Data
{
   public static class StartupExtension
    {
        public static IServiceCollection ConfigureMySqlContext(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseMySql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SW.Data")));

            return services;
        }
    }
}
