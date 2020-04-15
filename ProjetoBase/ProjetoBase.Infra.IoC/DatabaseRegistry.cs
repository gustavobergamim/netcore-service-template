using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoBase.Application.Queries;
using ProjetoBase.Application.Repositories;
using ProjetoBase.Infra.Data.EntityFramework;
using ProjetoBase.Infra.Data.EntityFramework.Queries;
using ProjetoBase.Infra.Data.EntityFramework.Repositories;

namespace ProjetoBase.Infra.IoC
{
    internal static class DatabaseRegistry
    {
        public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjetoBaseDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IQueries<>), typeof(BaseQueries<>));
        }
    }
}
