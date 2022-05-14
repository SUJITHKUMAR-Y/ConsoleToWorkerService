using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleToSevice
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient Client;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Client = new HttpClient();
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Client.Dispose();
            return base.StopAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
               // _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var result = await Client.GetAsync("https://google.com/");
                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation("The Website Is Up And The Status Code is: {statusCode}", result.StatusCode);
                }
                else
                {
                    _logger.LogInformation("The Website Is Down And The Status Code is: {statusCode}", result.StatusCode);
                }
                await Task.Delay(5000, stoppingToken);
            }
        }

    }
}