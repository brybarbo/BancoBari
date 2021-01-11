using AutoMapper;
using Bryan.BancoBari.Application.Models;
using Bryan.BancoBari.Domain.Models;

namespace Bryan.BancoBari.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<HelloWorld, HelloWorldViewModel>();
        }
    }
}
