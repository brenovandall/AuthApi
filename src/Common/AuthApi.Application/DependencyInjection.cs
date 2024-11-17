using AuthApi.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AuthApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(assembly));

        services.AddScoped<IJwtProvider, JwtProvider>();

        return services;
    }
}
