using Microsoft.Extensions.DependencyInjection;
using PatasSolidarias.Domain.Interfaces.Services;
using PatasSolidarias.Domain.Services;

namespace PatasSolidarias.Domain.Extensions;

public static class DomainExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<ICampanhaService, CampanhaService>();
        return services;
    }
}