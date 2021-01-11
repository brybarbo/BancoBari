using AutoMapper;
using Bryan.BancoBari.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bryan.BancoBari.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}
