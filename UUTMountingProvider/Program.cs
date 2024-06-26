using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpikeDemo.EFCore;
using SpikeDemo.Model;
using UUTMounting.Extensions;
using UUTMountingProvider.DbServiceConfigurator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.ConfigureServicesInAssembly(configuration);

builder.Services.AddMvc();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseApplication();
app.UseAuthorization();

app.MapControllers();

app.Run();
