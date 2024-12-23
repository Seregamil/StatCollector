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
var dbHost = Environment.GetEnvironmentVariable("DB_HOST") 
              ?? throw new Exception("DB_HOST not setted");

var dbPort = Environment.GetEnvironmentVariable("DB_PORT") 
              ?? throw new Exception("DB_PORT not setted");

var dbUser = Environment.GetEnvironmentVariable("DB_USER") 
              ?? throw new Exception("DB_USER not setted");

var dbPwd = Environment.GetEnvironmentVariable("DB_PASSWORD") 
            ?? throw new Exception("DB_PASSWORD not setted");

var dbName = Environment.GetEnvironmentVariable("DB_NAME") 
            ?? throw new Exception("DB_NAME not setted");

var dbSchema = Environment.GetEnvironmentVariable("DB_SCHEMA") 
              ?? throw new Exception("DB_SCHEMA not setted");

const string connectionStringPattern = "Host={0};Port={1};Username={2};Password={3};Database={4};SearchPath={5}";

var connectionString = string.Format(connectionStringPattern,
    dbHost,
    dbPort,
    dbUser,
    dbPwd,
    dbName,
    dbSchema);

builder.Services
    .AddDbContext<PipelineContext>(options =>
        options.UseNpgsql(connectionString));

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