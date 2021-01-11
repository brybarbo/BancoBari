using Bryan.BancoBari.Domain.Interfaces;
using Bryan.BancoBari.Domain.Message;
using Bryan.BancoBari.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bryan.BancoBari.Domain.Command
{
    public class HelloWorldCommandHandler : IRequestHandler<RegisterNewSendHelloWorldCommand, HelloWorld>
    {
        private readonly IMessageProducer _messageProducer;
        private readonly string _topicName;
        private readonly Guid _serviceId;

        public HelloWorldCommandHandler(IMessageProducer messageProducer)
        {
            _serviceId = Guid.NewGuid();
            _topicName = "topic-teste-hello-world";
            _messageProducer = messageProducer;
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
            _messageProducer.SendMessageAsync(_topicName, message).Wait();
        }

    }
}
