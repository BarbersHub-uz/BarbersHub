using AutoMapper;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Domain.Entities.Users;
using BarbersHub.Domain.Entities.Assets;
using BarbersHub.Service.DTOs.Users.Users;
using BarbersHub.Domain.Entities.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.Barbers;
using BarbersHub.Service.DTOs.BarberShops.BarberShops;

namespace BarbersHub.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();

        CreateMap<Barber, BarberForResultDto>().ReverseMap();
        CreateMap<Barber, BarberForUpdateDto>().ReverseMap();
        CreateMap<Barber, BarberForCreationDto>().ReverseMap();

        CreateMap<BarberShop, BarberShopForUpdateDto>().ReverseMap();
        CreateMap<BarberShop, BarberShopForResultDto>().ReverseMap();
        CreateMap<BarberShop, BarberShopForCreationDto>().ReverseMap();

        // Assets
        CreateMap<UserAsset, UserAssetForResultDto>().ReverseMap();
        CreateMap<BarberAsset, BarberAssetForResultDto>().ReverseMap();
        CreateMap<BarberShopAsset, BarberShopAssetForResultDto>().ReverseMap();

    }
}
