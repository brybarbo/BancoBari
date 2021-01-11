using Autofac;
using Bryan.BancoBari.Application.Models;
using Bryan.BancoBari.Domain.Testing.Factories;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Bryan.BancoBari.Domain.Testing.UnitTest
{
    [TestFixture]
    public class HelloWorldDomainTest : BaseDomainTests
    {
        private readonly HelloWorldFactory factory;

        public HelloWorldDomainTest()
        {
            factory = container.Resolve<HelloWorldFactory>();
        }

        [Test]
        public async Task Register_Async()
        {
            try
            {
                var helloWorldViewModel = new HelloWorldViewModel { Description = "Teste Bryan" };
                await factory.RegisterAsync(helloWorldViewModel);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}
