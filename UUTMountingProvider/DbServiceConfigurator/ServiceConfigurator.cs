using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UUTMountingProvider.DbServiceConfigurator;

public static class ServiceCollectionExtensions
{
    public static void ConfigureServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
    {
        DatabaseConnectionManager.ConfigureDatabase(services, configuration);
    }
}
