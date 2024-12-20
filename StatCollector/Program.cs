using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using ServiceMan.BaseLibrary.Extensions;
using ServiceMan.BaseLibrary.Middlewares;
using StatCollector.Data;
using StatCollector.Repositories.Abstract;
using StatCollector.Repositories.Impl;
using StatCollector.Services.Abstract;
using StatCollector.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
var logLevel = builder.Configuration.GetValue<LogEventLevel?>("LogLevel") ?? LogEventLevel.Debug;

Log.Logger = LogExtension
    .GetLoggerConfiguration(logLevel)
    .CreateBootstrapLogger();

builder.Host.UseSerilog();

// Add context to the container.
builder.Services
    .AddDbContext<PipelineContext>(options =>
        options.UseNpgsql(builder.Configuration.GetValue<string>("PostgresConnectionString")));

// Add repositories layer
builder.Services
    .AddScoped<IJobsRepository, JobsRepository>()
    .AddScoped<IUsersRepository, UsersRepository>();

// Add services layer
builder.Services
    .AddScoped<IJobsService, JobsService>()
    .AddScoped<IUsersService, UsersService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ExceptionHandler>();

using (var scope = app.Services.CreateScope())
{
    await using var dbContext = scope.ServiceProvider.GetRequiredService<PipelineContext>();
    await dbContext.Database.MigrateAsync();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.MapControllers();
app.Run();