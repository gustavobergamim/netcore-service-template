using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Serilog;
using ProjetoBase.Console.Startup;

namespace ProjetoBase.Console
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration(ConfigurationStartup.AddConfiguration)
                .ConfigureServices(ServicesStartup.AddServices)
                .ConfigureLogging(LoggingStartup.AddLogging)
                .UseConsoleLifetime()
                .Build();
            await host.RunAsync();
            Log.CloseAndFlush();
        }
    }
}