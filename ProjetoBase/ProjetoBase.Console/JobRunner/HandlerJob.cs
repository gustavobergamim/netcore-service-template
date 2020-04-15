using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ProjetoBase.Console.JobRunner
{
    internal class HandlerJob : IHostedService
    {
        private readonly IHostApplicationLifetime _hostLifetime;
        private readonly ILogger _logger;
        private readonly IEnumerable<IJob> _jobs;

        public HandlerJob(IHostApplicationLifetime hostLifetime, ILogger<HandlerJob> logger, IEnumerable<IJob> jobs)
        {
            _hostLifetime = hostLifetime;
            _logger = logger;
            _jobs = jobs;
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            try
            {
                await Task.WhenAll(_jobs.Select(j =>
                {
                    _logger.LogInformation($"Executing job {j.GetType().Name}");
                    return j.ExecuteAsync(cancellationToken);
                }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while executing jobs.");
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await RunAsync(cancellationToken);
            _hostLifetime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
