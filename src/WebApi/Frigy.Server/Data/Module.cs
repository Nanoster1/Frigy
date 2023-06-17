namespace Frigy.Server.Data;

public static class Module
{
    public static IServiceCollection AddData(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<FrigyContext>(options => FrigyContext.Configure(options, configuration));
        return services;
    }
}