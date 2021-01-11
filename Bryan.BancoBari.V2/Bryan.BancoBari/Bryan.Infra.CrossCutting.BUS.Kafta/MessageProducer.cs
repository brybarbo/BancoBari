using System;
using System.Threading.Tasks;

namespace Bryan.Infra.CrossCutting.BUS.Kafta
{
    public class MessageProducer : IMessageProducer
    {
        public async Task SendMessageAsync<T>(string topicName, Message<T> message) where T : class
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            using var producer = new ProducerBuilder<Null, string>(config).Build();
            var result = await producer.ProduceAsync(topicName, new Message<Null, string> { Value = JsonSerializer.Serialize(message) });

            Console.WriteLine(result.Value);
            Console.ReadLine();
        }
    }
}
