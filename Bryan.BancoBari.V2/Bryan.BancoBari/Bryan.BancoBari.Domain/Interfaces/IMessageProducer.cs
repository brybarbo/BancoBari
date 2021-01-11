using Bryan.BancoBari.Domain.Message;
using System.Threading.Tasks;

namespace Bryan.BancoBari.Domain.Interfaces
{
    public interface IMessageProducer
    {
        Task SendMessageAsync<T>(string queueName, Message<T> message) where T : class;
    }
}
