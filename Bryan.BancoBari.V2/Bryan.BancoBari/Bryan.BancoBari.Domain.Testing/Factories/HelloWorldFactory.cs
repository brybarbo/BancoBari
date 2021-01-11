using Bryan.BancoBari.Application.Interface;
using Bryan.BancoBari.Application.Models;
using Bryan.BancoBari.Domain.Testing.Factories.Interface;
using System.Threading.Tasks;

namespace Bryan.BancoBari.Domain.Testing.Factories
{
    public class HelloWorldFactory : IBaseDomainTestFactory
    {
        private readonly IHelloWorldAppService _helloWorldAppService;

        public HelloWorldFactory(IHelloWorldAppService helloWorldAppService)
        {
            _helloWorldAppService = helloWorldAppService;
        }

        public async Task RegisterAsync(HelloWorldViewModel helloWorldViewModel)
        {
            await _helloWorldAppService.RegisterAsync(helloWorldViewModel);
        }
    }
}

