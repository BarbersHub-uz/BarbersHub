﻿using AutoMapper;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Domain.Entities.Users;
using BarbersHub.Domain.Entities.Assets;
using BarbersHub.Service.DTOs.Users.Users;
using BarbersHub.Domain.Entities.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.Barbers;
using BarbersHub.Service.DTOs.BarberShops.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.BarberStyles;
using BarbersHub.Service.DTOs.BarberShops.Styles;

namespace BarbersHub.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();

        CreateMap<UserAsset, UserAssetForResultDto>().ReverseMap();


        CreateMap<Barber, BarberForResultDto>().ReverseMap();
        CreateMap<Barber, BarberForUpdateDto>().ReverseMap();
        CreateMap<Barber, BarberForCreationDto>().ReverseMap();

        CreateMap<BarberShop, BarberShopForUpdateDto>().ReverseMap();
        CreateMap<BarberShop, BarberShopForResultDto>().ReverseMap();
        CreateMap<BarberShop, BarberShopForCreationDto>().ReverseMap();

        //BarberStyle
        CreateMap<BarberStyle, BarberStyleForCreationDto>().ReverseMap();
        CreateMap<BarberStyle, BarberStyleForResultDto>().ReverseMap();
        CreateMap<BarberStyle, BarberStyleForUpdateDto>().ReverseMap();

        //Style
        CreateMap<Style, StyleForCreationDto>().ReverseMap();
        CreateMap<Style, StyleForUpdateDto>().ReverseMap();
        CreateMap<Style, StyleForResultDto>().ReverseMap();


    }
}
