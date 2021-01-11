using Bryan.BancoBari.Domain.Interfaces;
using Bryan.BancoBari.Domain.Message;
using Confluent.Kafka;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bryan.Infra.CrossCutting.Kafta
{
    public class MessageProducer : IMessageProducer
    {
        public async Task SendMessageAsync<T>(string topicName, Message<T> message) where T : class
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();
            var result = await producer.ProduceAsync(topicName, new Message<Null, string> { Value = JsonSerializer.Serialize(message) });
        }
    }
}
