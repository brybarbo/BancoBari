using Bryan.BancoBari.Domain.Interfaces;
using Bryan.BancoBari.Domain.Message;
using Bryan.BancoBari.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Bryan.BancoBari.Domain.Command
{
    public class HelloWorldCommandHandler : IRequestHandler<RegisterNewSendHelloWorldCommand, HelloWorld>
    {
        private readonly IMessageProducer _messageProducer;
        private readonly string _topicName;
        private readonly Guid _serviceId;
        private readonly ILogger<HelloWorldCommandHandler> _log;

        public HelloWorldCommandHandler(IMessageProducer messageProducer, ILogger<HelloWorldCommandHandler> log)
        {
            _serviceId = Guid.NewGuid();
            _topicName = "topic-customer-hello-world";
            _messageProducer = messageProducer;
            _log = log;
        }

        public async  Task<HelloWorld> Handle(RegisterNewSendHelloWorldCommand request, CancellationToken cancellationToken)
        {
            var timer = new System.Timers.Timer(5000)
            {
                AutoReset = true,
                Enabled = true,
            };

            timer.Elapsed += (sender, e) => TimeElapsed(sender, e, new HelloWorldMessage(_serviceId, request.HelloWorld));
            return await Task.FromResult(request.HelloWorld);
        }

        private void TimeElapsed(object sender, System.Timers.ElapsedEventArgs e, HelloWorldMessage message)
        {
            _log.LogInformation($"[{nameof(HelloWorldCommandHandler)}][{nameof(TimeElapsed)}]Posted|{JsonSerializer.Serialize(message)}");

            _messageProducer.SendMessageAsync(_topicName, message).Wait();
        }

    }
}
