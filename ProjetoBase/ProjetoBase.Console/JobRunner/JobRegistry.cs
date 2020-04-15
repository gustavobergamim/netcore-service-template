using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using ProjetoBase.Console.Jobs;
using ProjetoBase.Domain.Configuration;

namespace ProjetoBase.Console.JobRunner
{
    internal static class JobRegistry
    {
        public static void AddJobs(this IServiceCollection services, ProjetoBaseConfig config)
        {
            //Creates a collection with available jobs to run
            var jobs = new[]
            {
                typeof(ExemploJob)
            };

            //Register all jobs or jobs specified at configuration file
            foreach (var jobType in jobs.Where(jt => config.JobsToRun is null || config.JobsToRun.Contains(jt.Name)))
            {
                services.AddTransient(typeof(IJob), jobType);
            }
        }
    }
}
