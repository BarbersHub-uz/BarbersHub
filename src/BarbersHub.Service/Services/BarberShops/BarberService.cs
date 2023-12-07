using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.Barbers;

namespace BarbersHub.Service.Services.BarberShops;

public class BarberService : IBarberService
{
    public Task<BarberForResultDto> AddAsync(BarberForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<BarberForResultDto> ModifyAsync(long id, BarberForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BarberForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<BarberForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
