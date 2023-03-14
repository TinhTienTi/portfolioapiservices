using PortfolioServices.Api.Infracstructure;
using PortfolioServices.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration(configuration =>
{
    configuration.AddJsonFile(@"json/databases.json", optional: true, reloadOnChange: true);
})
    .UseContentRoot(Directory.GetCurrentDirectory());

SeedData.InitializeDatabase(builder.Configuration["PortfolioService:ConnectionString"]);

builder.Services.AddConfigureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
await app.AddConfigureAsync();