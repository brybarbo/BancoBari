using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bryan.BancoBari.Service.Consumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var cancellationTokenSource = new CancellationTokenSource();
                var config = new ConsumerConfig
                {
                    BootstrapServers = "localhost:9092",
                    GroupId = $"topic-teste-group-0",
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                try
                {
                    using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
                    consumer.Subscribe("topic-teste-hello-world");

                    try
                    {
                        while (true)
                        {
                            var cr = consumer.Consume(cancellationTokenSource.Token);
                            Console.WriteLine(cr);
                            Console.ReadLine();
                        }
                    }
                    catch (OperationCanceledException oce)
                    {
                        _logger.LogError(oce, "Worker running at: {time}", DateTimeOffset.Now);
                        consumer.Close();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Worker running at: {time}", DateTimeOffset.Now);
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}
