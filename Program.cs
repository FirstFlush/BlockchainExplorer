using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using BlockchainExplorer.App.Services;
using DotNetEnv; // Moved import inside using section

// Load the .env file to access environment variables
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Configure logging with Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
    .WriteTo.File(
        "logs/log-.txt", 
        rollingInterval: RollingInterval.Day, 
        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning
    )
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddScoped<IBlockchainService, BlockchainService>();

// Add Swagger services for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
