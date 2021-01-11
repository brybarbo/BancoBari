using AutoMapper;
using Bryan.BancoBari.Application.Interface;
using Bryan.BancoBari.Application.Models;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using MediatR;
using Bryan.BancoBari.Domain.Command;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Bryan.BancoBari.Application.Services
{
    public class HelloWorldAppService : IHelloWorldAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<HelloWorldAppService> _log;

        public HelloWorldAppService(IMapper mapper, IMediator mediator, ILogger<HelloWorldAppService> log)
        {
            _mapper = mapper;
            _mediator = mediator;
            _log = log;
        }

        public async Task RegisterAsync(HelloWorldViewModel helloWorldViewModel)
        {
            _log.LogInformation($"[{nameof(HelloWorldAppService)}][{nameof(RegisterAsync)}]Posted|{JsonSerializer.Serialize(helloWorldViewModel)}");

            var registerCommand = _mapper.Map<RegisterNewSendHelloWorldCommand>(helloWorldViewModel);
            await _mediator.Send(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    
    }
}
