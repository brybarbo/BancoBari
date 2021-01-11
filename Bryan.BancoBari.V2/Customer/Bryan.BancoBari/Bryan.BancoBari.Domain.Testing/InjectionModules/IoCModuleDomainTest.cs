using Autofac;
using Bryan.BancoBari.Domain.Testing.Factories.Interface;
using Bryan.BancoBari.Domain.Testing.UnitTest;

namespace Bryan.BancoBari.Domain.Testing.InjectionModules
{
    public class IoCModuleDomainTest : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BaseDomainTests).Assembly)
                .Where(c => c.IsAssignableTo<IBaseDomainTestFactory>())
                .AsSelf();
        }
    }
}
