using AutoMapper;
using BarbersHub.Domain.Entities.Users;
using BarbersHub.Service.DTOs.Users.Users;

namespace BarbersHub.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();
    }
}
