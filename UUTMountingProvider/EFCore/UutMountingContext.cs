using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;

namespace SpikeDemo.EFCore
{
    public class UutMountingContext : DbContext
    {
        public UutMountingContext(DbContextOptions<UutMountingContext> options) : base(options) { }

        public DbSet<UutMountingInformation> UutMountingData { get; set; }
        public DbSet<MeasurementConfiguration> MeasurementConfigurationData { get; set; }
    }
}

