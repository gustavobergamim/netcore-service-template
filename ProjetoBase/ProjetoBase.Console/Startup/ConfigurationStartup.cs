using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using static System.String;

namespace ProjetoBase.Console.Startup
{
    internal static class ConfigurationStartup
    {
        private const string EnvironmentKey = "ENVIRONMENT";
        private const string SerilogKey = "SERILOG_SETTINGS";

        private static string GetEnvironmentVariable(string name)
        {
            var value = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine);
            return !IsNullOrEmpty(value) ? value : Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }

        public static void AddConfiguration(HostBuilderContext hostContext, IConfigurationBuilder configApp)
        {
            var serilog = GetEnvironmentVariable(SerilogKey);
            SetEnvironment(hostContext);
            configApp.AddJsonFile("appsettings.json");
            configApp.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", true);
            if (!IsNullOrEmpty(serilog))
            {
                configApp.AddJsonFile(Format("appsettings.{0}.json", serilog), true, true);
            }
            configApp.AddEnvironmentVariables();
        }

        private static void SetEnvironment(HostBuilderContext hostContext)
        {
            var environment = GetEnvironmentVariable(EnvironmentKey);
            if (!IsNullOrEmpty(environment))
            {
                hostContext.HostingEnvironment.EnvironmentName = environment;
            }
        }
    }
}
