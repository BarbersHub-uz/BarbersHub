using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.Styles;

namespace BarbersHub.Service.Services.BarberShops;

public class StyleService : IStyleService
{
    public Task<StyleForResultDto> AddAsync(StyleForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<StyleForResultDto> ModifyAsync(long id, StyleForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<StyleForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<StyleForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
