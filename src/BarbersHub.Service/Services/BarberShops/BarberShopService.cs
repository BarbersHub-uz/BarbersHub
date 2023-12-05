using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.BarberShops;

namespace BarbersHub.Service.Services.BarberShops;

public class BarberShopService : IBarberShopService
{
    public Task<BarberShopForResultDto> AddAsync(BarberShopForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<BarberShopForResultDto> ModifyAsync(long id, BarberShopForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BarberShopForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<BarberShopForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
