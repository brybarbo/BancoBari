using AutoMapper;
using Bryan.BancoBari.Application.Interface;
using Bryan.BancoBari.Application.Models;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using MediatR;
using Bryan.BancoBari.Domain.Command;
using Bryan.BancoBari.Domain.Models;

namespace Bryan.BancoBari.Application.Services
{
    public class HelloWorldAppService : IHelloWorldAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public HelloWorldAppService(IMapper mapper,
                          IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task RegisterAsync(HelloWorldViewModel helloWorldViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewSendHelloWorldCommand>(helloWorldViewModel);
            await _mediator.Send(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    
    }
}
