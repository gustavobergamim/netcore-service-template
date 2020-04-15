using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace ProjetoBase.WebApi.StartupConfig
{
    public static class SerilogConfig
    {
        private const string EnvVarSettings = "SERILOG_SETTINGS";

        public static IWebHostBuilder AddSerilog(this IWebHostBuilder webHostBuilder)
            => webHostBuilder
                .ConfigureAppConfiguration(AddSerilogSettings)
                .UseSerilog((hosting, logger) => logger.ReadFrom.Configuration(hosting.Configuration));

        private static void AddSerilogSettings(WebHostBuilderContext hosting, IConfigurationBuilder builder)
        {
            var serilogSettings = EnvironmentHelper.GetEnvVar(EnvVarSettings);
            if (!String.IsNullOrEmpty(serilogSettings))
            {
                builder.AddJsonFile(String.Format("appsettings.{0}.json", serilogSettings), true, true);
            }
            builder.AddEnvironmentVariables();
        }
    }
}

