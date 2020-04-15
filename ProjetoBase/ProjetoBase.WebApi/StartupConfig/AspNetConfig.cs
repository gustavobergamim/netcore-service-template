using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoBase.WebApi.StartupConfig
{
    public static class AspNetConfig
    {
        private const string CorsPolicy = "CORS_Policy";

        public static void RegisterAspNet(this IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.Configure<ApiBehaviorOptions>(opt => { opt.SuppressModelStateInvalidFilter = true; });

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddHttpContextAccessor();
        }

        public static void ConfigureCors(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(CorsPolicy);
        }

        public static void ConfigureAspNet(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMvc();
            app.UseHealthChecks("/health");
        }
    }
}





