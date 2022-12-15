using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExampleService
{
    public class ExampleHostedService : BackgroundService
    {
        private readonly ILogger<ExampleHostedService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ExampleHostedService(
            ILogger<ExampleHostedService> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Starting {nameof(ExampleHostedService)}");
            try
            {
                //Действия при старте сервиса. Например, запуск реббита 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during start bus");
            }
            cancellationToken.Register(() => _logger.LogInformation($"{nameof(ExampleHostedService)} task is stopping."));
            return base.StartAsync(cancellationToken);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Started {nameof(ExampleHostedService)}");
            return Task.CompletedTask;
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            //Действия при останове сервиса 
            return base.StopAsync(cancellationToken);
        }
    }
}
