using Bryan.BancoBari.Application.Models;
using System;
using System.Threading.Tasks;

namespace Bryan.BancoBari.Application.Interface
{
    public interface IHelloWorldAppService : IDisposable
    {
        Task RegisterAsync(HelloWorldViewModel helloWorldViewModel);
    }
}
