using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatasSolidaras.Infra.Contexts;

namespace PatasSolidaras.Infra.Extensions;

public static class DependencyInjection
{
    public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration cfg)
    {
        AddContext(services, cfg);
    }

    private static void AddContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
    }
}