using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.BarberStyles;

namespace BarbersHub.Service.Services.BarberShops;

public class BarberStyleService : IBarberStyleService
{
    public Task<BarberStyleForResultDto> AddAsync(BarberStyleForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<BarberStyleForResultDto> ModifyAsync(long id, BarberStyleForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BarberStyleForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<BarberStyleForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
