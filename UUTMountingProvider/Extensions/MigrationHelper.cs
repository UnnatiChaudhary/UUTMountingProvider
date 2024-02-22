using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpikeDemo.EFCore;
using System.Reflection.Metadata.Ecma335;

namespace UUTMounting.Extensions
{
    public static class MigrationHelper
    {
        public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                using (var context=scope.ServiceProvider.GetRequiredService<UutMountingContext>())
                {
                    context.Database.EnsureCreated();

                }
            }
            return app;
        }
    }
}
