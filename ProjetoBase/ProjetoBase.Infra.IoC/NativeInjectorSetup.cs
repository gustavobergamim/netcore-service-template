using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoBase.Infra.IoC
{
    public static class NativeInjectorSetup
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterCommand();
            services.RegisterApplication(configuration);
            services.RegisterDatabase(configuration);
        }
    }
}
