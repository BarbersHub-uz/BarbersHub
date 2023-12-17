using BarbersHub.Service.Mappers;
using BarbersHub.Service.Helpers;
using BarbersHub.Data.Repositories;
using BarbersHub.Data.IRepositories;
using BarbersHub.Service.Services.Users;
using BarbersHub.Service.Services.Assets;
using BarbersHub.Service.Services.Orders;
using BarbersHub.Service.Interfaces.Users;
using BarbersHub.Service.Interfaces.Orders;
using BarbersHub.Service.Services.Accounts;
using BarbersHub.Service.Interfaces.Assets;
using BarbersHub.Service.Services.Favorites;
using BarbersHub.Service.Interfaces.Accounts;
using BarbersHub.Service.Interfaces.Favorites;
using BarbersHub.Service.Services.BarberShops;
using BarbersHub.Service.Services.AuthServices;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.Interfaces.AuthServices;

namespace BarbersHub.Api.Extensions;

public static class ServiceExtension
{
    public static void AddCustomService(this IServiceCollection services)
    {
        // Mapping Profile
        services.AddAutoMapper(typeof(MappingProfile));

        // EnvironmentHelper
        services.AddScoped<EnvironmentHelper, EnvironmentHelper>();

        // Repository
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        //Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IStyleService, StyleService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IBarberService, BarberService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IFavoriteService, FavoriteService>();
        services.AddScoped<IBarberShopService, BarberShopService>();
        services.AddScoped<IBarberStyleService, BarberStyleService>();

        //Asset Services
        services.AddScoped<IUserAssetService, UserAssetService>();
        services.AddScoped<IStyleAssetService, StyleAssetService>();
        services.AddScoped<IBarberAssetService, BarberAssetService>();
        services.AddScoped<IBarberShopAssetService, BarberShopAssetService>();
    }
}
