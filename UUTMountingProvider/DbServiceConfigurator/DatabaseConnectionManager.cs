using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpikeDemo.EFCore;

namespace UUTMountingProvider.DbServiceConfigurator
{
    public class DatabaseConnectionManager
    {
        public static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
        {
            string databaseChoice = configuration.GetValue<string>("DatabaseChoice");

            switch (databaseChoice)
            {
                case "SQLite":
                    services.AddDbContext<UutMountingContext>(options =>
                        options.UseSqlite(configuration.GetConnectionString("SQLiteConnection")));
                    break;
                case "PostgreSQL":
                    services.AddDbContext<UutMountingContext>(options =>
                        options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection")));
                    break;
                 case "Oracle":
                     services.AddDbContext<UutMountingContext>(options =>
                     options.UseOracle(configuration.GetConnectionString("OracleConnection")));
                     break;
                default:
                    throw new InvalidOperationException("Invalid database choice specified in appsettings.json.");
            }
        }
    }
}
