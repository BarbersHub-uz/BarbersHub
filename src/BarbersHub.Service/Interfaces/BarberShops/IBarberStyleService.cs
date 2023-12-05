using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.BarberShops.BarberStyles;

namespace BarbersHub.Service.Interfaces.BarberShops;

public interface IBarberStyleService
{
    Task<bool> RemoveAsync(long id);
    Task<BarberStyleForResultDto> RetrieveByIdAsync(long id);
    Task<BarberStyleForResultDto> AddAsync(BarberStyleForCreationDto dto);
    Task<BarberStyleForResultDto> ModifyAsync(long id, BarberStyleForUpdateDto dto);
    Task<IEnumerable<BarberStyleForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
