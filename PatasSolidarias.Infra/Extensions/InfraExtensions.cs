using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatasSolidaras.Infra.Repositories;
using PatasSolidarias.Domain.Interfaces.Repositories;

namespace PatasSolidaras.Infra.Extensions;

public static class InfraExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        
        return services;
    }
}