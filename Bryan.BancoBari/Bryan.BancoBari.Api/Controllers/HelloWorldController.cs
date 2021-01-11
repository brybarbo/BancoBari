using Bryan.BancoBari.Application.Interface;
using Bryan.BancoBari.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bryan.BancoBari.Api.Controllers
{
    public class HelloWorldController : ApiController
    {
        private readonly IHelloWorldAppService _helloWorldAppService;
        public HelloWorldController(IHelloWorldAppService helloWorldAppService)
        {
            _helloWorldAppService = helloWorldAppService;
        }

        [AllowAnonymous]
        [HttpPost("helloworld-send-message")]
        public async Task<IActionResult> Post(HelloWorldViewModel helloWorldViewModel)
        {
            await _helloWorldAppService.RegisterAsync(helloWorldViewModel);
            return Ok();
        }
    }
}
