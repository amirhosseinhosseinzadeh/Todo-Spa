using AutoMapper;
using Todo.Api.Dtos;
using Todo.Api.Entities;

namespace Todo.Api.MapperConfiguration;
public class AutoMapperConfigs : Profile
{
    public AutoMapperConfigs()
    {
        CreateMap<Application,ApplicationDto>()
            .ReverseMap();
    }
}