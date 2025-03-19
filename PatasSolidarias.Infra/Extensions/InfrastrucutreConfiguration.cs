using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatasSolidaras.Infra.Contexts;

namespace PatasSolidaras.Infra.Extensions;

public static class DependencyInjection
{
    public static void RegisterInfrastructure(this IServiceCollection service, IConfiguration cfg)
    {
        AddContext(service, cfg);
    }

    private static void AddContext(IServiceCollection service, IConfiguration cfg)
    {
        service.AddNpgsql<ApplicationDbContext>(cfg.GetConnectionString("WriteDatabaseConnection"));

    }
}