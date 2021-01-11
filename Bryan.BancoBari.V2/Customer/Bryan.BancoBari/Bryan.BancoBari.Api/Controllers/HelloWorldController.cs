using Bryan.BancoBari.Application.Interface;
using Bryan.BancoBari.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bryan.BancoBari.Api.Controllers
{
    public class HelloWorldController : ApiController
    {
        private readonly IHelloWorldAppService _helloWorldAppService;

        private readonly ILogger<HelloWorldController> _log;

        public HelloWorldController(IHelloWorldAppService helloWorldAppService, ILogger<HelloWorldController> log)
        {
            _helloWorldAppService = helloWorldAppService;
            _log = log;
        }

        [AllowAnonymous]
        [HttpPost("helloworld-send-message")]
        public async Task<IActionResult> Post(HelloWorldViewModel helloWorldViewModel)
        {
            _log.LogInformation($"[{nameof(HelloWorldController)}][{nameof(Post)}]Posted|{JsonSerializer.Serialize(helloWorldViewModel)}");

            await _helloWorldAppService.RegisterAsync(helloWorldViewModel);
            return Ok();
        }
    }
}
