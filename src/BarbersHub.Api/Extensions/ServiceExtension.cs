using BarbersHub.Service.Mappers;
using BarbersHub.Data.Repositories;
using BarbersHub.Data.IRepositories;
using BarbersHub.Service.Interfaces.Assets;
using BarbersHub.Service.Services.Assets;
using BarbersHub.Service.Helpers;
using System.Security.Principal;
using BarbersHub.Service.Interfaces.Users;
using BarbersHub.Service.Services.Users;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.Services.BarberShops;

namespace BarbersHub.Api.Extensions;

public static class ServiceExtension 
{
    public static void AddCustomService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddAutoMapper(typeof(MappingProfile));

        services.AddScoped<EnvironmentHelper, EnvironmentHelper>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserAssetService, UserAssetService>();

        services.AddScoped<IBarberShopService, BarberShopService>();
    }
}
