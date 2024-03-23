using AutoMapper;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Domain.Entities.Users;
using BarbersHub.Domain.Entities.Assets;
using BarbersHub.Domain.Entities.Orders;
using BarbersHub.Service.DTOs.Users.Users;
using BarbersHub.Domain.Entities.Favorites;
using BarbersHub.Service.DTOs.Orders.Orders;
using BarbersHub.Domain.Entities.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.Styles;
using BarbersHub.Service.DTOs.BarberShops.Barbers;
using BarbersHub.Service.DTOs.Favorites.Favorites;
using BarbersHub.Service.DTOs.BarberShops.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.BarberStyles;

namespace BarbersHub.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();

        // Style
        CreateMap<Style, StyleForUpdateDto>().ReverseMap();
        CreateMap<Style, StyleForResultDto>().ReverseMap();
        CreateMap<Style, StyleForCreationDto>().ReverseMap();

        //Order
        CreateMap<Order, OrderForResultDto>().ReverseMap();
        CreateMap<Order, OrderForUpdateDto>().ReverseMap();
        CreateMap<Order, OrderForCreationDto>().ReverseMap();

        // Barber
        CreateMap<Barber, BarberForResultDto>().ReverseMap();
        CreateMap<Barber, BarberForUpdateDto>().ReverseMap();
        CreateMap<Barber, BarberForCreationDto>().ReverseMap();

        // Favorite
        CreateMap<Favorite, FavoriteForResultDto>().ReverseMap();
        CreateMap<Favorite, FavoriteForUpdateDto>().ReverseMap();
        CreateMap<Favorite, FavoriteForCreationDto>().ReverseMap();
        
        // BarberShop
        CreateMap<BarberShop, BarberShopForUpdateDto>().ReverseMap();
        CreateMap<BarberShop, BarberShopForResultDto>().ReverseMap();
        CreateMap<BarberShop, BarberShopForCreationDto>().ReverseMap();

        // BarberStyle
        CreateMap<BarberStyle, BarberStyleForResultDto>().ReverseMap();
        CreateMap<BarberStyle, BarberStyleForUpdateDto>().ReverseMap();
        CreateMap<BarberStyle, BarberStyleForCreationDto>().ReverseMap();

        // Assets
        CreateMap<UserAsset, UserAssetForResultDto>().ReverseMap();
        CreateMap<StyleAsset, StyleAssetForResultDto>().ReverseMap();
        CreateMap<BarberAsset, BarberAssetForResultDto>().ReverseMap();
        CreateMap<BarberShopAsset, BarberShopAssetForResultDto>().ReverseMap();


    }
}
