using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Logging;

namespace Bryan.BancoBari.Service.Kafka.Consumer
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
                try
                {
                    var config = new ConsumerConfig
                    {
                        BootstrapServers = "localhost:9092",
                        GroupId = $"topic-teste-hello-world-group-0",
                        AutoOffsetReset = AutoOffsetReset.Earliest
                    };

                    var cancellationTokenSource = new CancellationTokenSource();
                    using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
                    consumer.Subscribe("topic-teste-hello-world");

                    try
                    {
                        while (true)
                        {
                            var consumeResult = consumer.Consume(cancellationTokenSource.Token);
                            _logger.LogInformation(consumeResult.Message.Value);
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumer.Close();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Worker running at: {time}", DateTimeOffset.Now);
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
