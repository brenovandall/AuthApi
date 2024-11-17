using Carter;

namespace AuthApi.App;

public static class DependencyInjection
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddCarter();

        return services;
    }

    public static WebApplication UseAppServices(this WebApplication app)
    {
        app.MapCarter();

        return app;
    }
}
