using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.BarberShops.Styles;

namespace BarbersHub.Service.Interfaces.BarberShops;

public interface IStyleService
{
    Task<bool> RemoveAsync(long id);
    Task<StyleForResultDto> RetrieveByIdAsync(long id);
    Task<StyleForResultDto> AddAsync(StyleForCreationDto dto);
    Task<StyleForResultDto> ModifyAsync(long id, StyleForUpdateDto dto);
    Task<IEnumerable<StyleForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
