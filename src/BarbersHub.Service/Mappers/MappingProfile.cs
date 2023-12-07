using AutoMapper;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Domain.Entities.Users;
using BarbersHub.Domain.Entities.Assets;
using BarbersHub.Service.DTOs.Users.Users;
using BarbersHub.Domain.Entities.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.BarberShops;

namespace BarbersHub.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();

        CreateMap<UserAsset, UserAssetForResultDto>().ReverseMap();

        // BarberShop

        CreateMap<BarberShop, BarberShopForUpdateDto>().ReverseMap();
        CreateMap<BarberShop, BarberShopForResultDto>().ReverseMap();
        CreateMap<BarberShop, BarberShopForCreationDto>().ReverseMap();

        // BarberShop Asset
        CreateMap<BarberShopAsset, BarberShopAssetForResultDto>().ReverseMap();
    }
}
