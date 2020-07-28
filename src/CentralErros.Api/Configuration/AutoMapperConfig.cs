using AutoMapper;
using CentralErros.Api.ViewModels;
using CentralErros.Business.Models;

namespace CentralErros.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Log, LogViewModel>().ReverseMap();
        }
    }
}
