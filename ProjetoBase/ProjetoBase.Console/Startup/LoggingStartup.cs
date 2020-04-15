using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ProjetoBase.Console.Startup
{
    internal static class LoggingStartup
    {
        public static void AddLogging(HostBuilderContext hostContext, ILoggingBuilder configLogging)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(hostContext.Configuration)
                .CreateLogger();
            configLogging.AddSerilog();
        }
    }
}
