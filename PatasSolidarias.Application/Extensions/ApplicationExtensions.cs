using Microsoft.Extensions.DependencyInjection;
using PatasSolidarias.Application.Interfaces;
using PatasSolidarias.Application.Services;

namespace PatasSolidarias.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();
        return services;
    }
}