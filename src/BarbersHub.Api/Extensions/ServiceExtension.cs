using BarbersHub.Data.Repositories;
using BarbersHub.Data.IRepositories;

namespace BarbersHub.Api.Extensions;

public static class ServiceExtension 
{
    public static void AddCustomService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

    }
}
