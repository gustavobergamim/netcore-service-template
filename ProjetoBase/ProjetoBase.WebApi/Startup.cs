using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoBase.Infra.IoC;
using ProjetoBase.WebApi.ErrorHandling;
using ProjetoBase.WebApi.StartupConfig;

namespace ProjetoBase.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
            services.RegisterAspNet();
            services.RegisterSwagger(Configuration);
            services.RegisterDependencies(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureCors(env);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureExceptionHandler();
            app.ConfigureAspNet(env);
            app.ConfigureSwagger(Configuration);
        }
    }
}
