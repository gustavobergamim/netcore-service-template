using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoBase.Infra.IoC;
using ProjetoBase.Console.JobRunner;
using ProjetoBase.Domain.Configuration;

namespace ProjetoBase.Console.Startup
{
    internal static class ServicesStartup
    {
        public static void AddServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            services.RegisterDependencies(hostContext.Configuration);
            AddJobs(hostContext, services);
        }

        private static void AddJobs(HostBuilderContext hostContext, IServiceCollection services)
        {
            var consoleConfig = hostContext.Configuration.GetSection("ProjetoBaseConfig").Get<ProjetoBaseConfig>();
            if (!(consoleConfig is null))
            {
                services.AddHostedService<HandlerJob>().AddJobs(consoleConfig);
            }
        }
    }
}
