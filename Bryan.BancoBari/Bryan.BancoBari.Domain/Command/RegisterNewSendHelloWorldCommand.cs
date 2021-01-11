using Bryan.BancoBari.Domain.Models;
using MediatR;
using System;

namespace Bryan.BancoBari.Domain.Command
{
    public class RegisterNewSendHelloWorldCommand : IRequest<HelloWorld>
    {
        public HelloWorld HelloWorld { get; set; }

        public RegisterNewSendHelloWorldCommand(Guid id, string description)
        {
            HelloWorld = new HelloWorld(id , description);
        }
    }
}
