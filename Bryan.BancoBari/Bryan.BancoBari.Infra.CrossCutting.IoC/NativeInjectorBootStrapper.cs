using Bryan.BancoBari.Application.Interface;
using Bryan.BancoBari.Application.Services;
using Bryan.BancoBari.Domain.Command;
using Bryan.BancoBari.Domain.Interfaces;
using Bryan.BancoBari.Domain.Models;
using Bryan.Infra.CrossCutting.Kafta;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace Bryan.BancoBari.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IHelloWorldAppService, HelloWorldAppService>();

            // Domain - Commands
            services.AddTransient<IRequestHandler<RegisterNewSendHelloWorldCommand, HelloWorld>, HelloWorldCommandHandler>();

            // Message Broker
            services.AddScoped<IMessageProducer, MessageProducer>();
        }
    }
}
