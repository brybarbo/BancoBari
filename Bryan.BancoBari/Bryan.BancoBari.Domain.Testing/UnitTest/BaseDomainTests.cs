using Autofac;
using Bryan.BancoBari.Domain.Testing.InjectionModules;

namespace Bryan.BancoBari.Domain.Testing.UnitTest
{
    public class BaseDomainTests
    {
        protected readonly IContainer container;

        protected BaseDomainTests()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new IoCModuleDomainTest());
            builder.RegisterModule(new IoCModuleApplicationService());
            container = builder.Build();
        }
    }
}
