using AutoMapper;
using Bryan.BancoBari.Application.Models;
using Bryan.BancoBari.Domain.Command;
using Bryan.BancoBari.Domain.Models;

namespace Bryan.BancoBari.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<HelloWorldViewModel, RegisterNewSendHelloWorldCommand>()
                .ConstructUsing(p => new RegisterNewSendHelloWorldCommand(p.Id, p.Description));
        }
    }
}
