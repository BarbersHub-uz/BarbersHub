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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStyleRepository, StyleRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IBarberRepository, BarberRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IFavoriteRepository, FavoriteRepository>();
        services.AddScoped<ICompletedRepository, CompletedRepository>();
        services.AddScoped<IBarberShopRepository, BarberShopRepository>();
        services.AddScoped<IBarberStyleRepository, BarberStyleRepository>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        //Services
        services.AddScoped<IUserAssetRepository, UserAssetRepository>();
        services.AddScoped<IStyleAssetRepository, StyleAssetRepository>();
        services.AddScoped<IBarberAssetRepository, BarberAssetRepository>();
        services.AddScoped<IBarberShopAssetRepository, BarberShopAssetRepository>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IStyleService, StyleService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IBarberService, BarberService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IFavoriteService, FavoriteService>();
        services.AddScoped<IUserAssetService, UserAssetService>();
        services.AddScoped<IStyleAssetService, StyleAssetService>();
        services.AddScoped<IBarberShopService, BarberShopService>();
        services.AddScoped<IBarberStyleService, BarberStyleService>();
        services.AddScoped<IBarberAssetService, BarberAssetService>();
        services.AddScoped<IBarberShopAssetService, BarberShopAssetService>();
    }

    public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            var Key = Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]);
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Key),
                ClockSkew = TimeSpan.FromMinutes(1)
            };
        });
    }
}
