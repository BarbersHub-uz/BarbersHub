using BarbersHub.Service.Mappers;
using BarbersHub.Service.Helpers;
using BarbersHub.Data.Repositories;
using BarbersHub.Data.IRepositories;
using BarbersHub.Service.Services.Users;
using BarbersHub.Service.Services.Assets;
using BarbersHub.Service.Interfaces.Users;
using BarbersHub.Service.Interfaces.Assets;
using BarbersHub.Service.Services.BarberShops;
using BarbersHub.Service.Interfaces.BarberShops;


namespace BarbersHub.Api.Extensions;

public static class ServiceExtension
{
    public static void AddCustomService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddAutoMapper(typeof(MappingProfile));

        services.AddScoped<EnvironmentHelper, EnvironmentHelper>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IBarberService, BarberService>();
        services.AddScoped<IUserAssetService, UserAssetService>();

        services.AddScoped<IBarberShopService, BarberShopService>();

        services.AddScoped<IBarberShopAssetService, BarberShopAssetService>();

        services.AddScoped<IBarberAssetService, BarberAssetService>();
    }
}
