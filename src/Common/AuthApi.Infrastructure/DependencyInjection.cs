using AuthApi.Application.Data;
using AuthApi.Infrastructure.CommandData;
using AuthApi.Infrastructure.Interceptors;
using AuthApi.Infrastructure.ReadData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISaveChangesInterceptor, DomainEventsInterceptor>();

        services.AddDbContext<CommandDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlite(configuration.GetConnectionString("c_db_connection"));
        });

        services.AddDbContext<ReadDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlite(configuration.GetConnectionString("r_db_connection"));
        });

        services.AddScoped<ICommandDbContext, CommandDbContext>();
        services.AddScoped<IReadDbContext, ReadDbContext>();

        return services;
    }
}
