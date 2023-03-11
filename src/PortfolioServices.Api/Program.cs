using PortfolioServices.Api.Infracstructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.ConfigureAppConfiguration(configuration =>
{
    configuration.AddJsonFile(@"json/databases.json", optional: true, reloadOnChange: true);
})
    .UseContentRoot(Directory.GetCurrentDirectory());

builder.Services.AddConfigureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
await app.AddConfigureAsync();