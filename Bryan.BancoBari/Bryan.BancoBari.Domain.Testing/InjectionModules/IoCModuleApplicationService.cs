using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Bryan.BancoBari.Application.AutoMapper;
using Bryan.BancoBari.Infra.CrossCutting.IoC;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Bryan.BancoBari.Domain.Testing.InjectionModules
{
    public class IoCModuleApplicationService : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfiguration configuration = new ConfigurationBuilder()
                .Build();

            var services = new ServiceCollection();
            builder.Register(context => configuration).As<IConfiguration>();
            NativeInjectorBootStrapper.RegisterServices(services);
            services.AddLogging();
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Populate(services);
            base.Load(builder);
        }
    }
}
