using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace ServiceMan.BaseLibrary.Extensions;

public static class LogExtension
{
    private const string OutputTemplate =
        "[{Timestamp:HH:mm:ss} {Level:u3} (#{ThreadId})]: {Message}{NewLine}{Exception:j}";

    public static LoggerConfiguration GetLoggerConfiguration(LogEventLevel logLevel)
    {
        var logger = new LoggerConfiguration()
            .Enrich.WithThreadId()
            .Enrich.WithExceptionDetails()
            .MinimumLevel.Is(logLevel)
            .WriteTo.Console(outputTemplate: OutputTemplate);

        return logger;
    }
}