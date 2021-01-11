using Bryan.BancoBari.Domain.Models;
using System;

namespace Bryan.BancoBari.Domain.Message
{
    public class HelloWorldMessage : Message<HelloWorld>
    {
        public HelloWorldMessage(Guid serviceId, HelloWorld helloWorld) : base(serviceId, helloWorld)
        {

        }
    }
}
