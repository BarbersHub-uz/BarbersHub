using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.BarberShops.BarberShops;

namespace BarbersHub.Service.Interfaces.BarberShops;

public interface IBarberShopService
{
    Task<bool> RemoveAsync(long id);
    Task<BarberShopForResultDto> RetrieveByIdAsync(long id);
    Task<BarberShopForResultDto> AddAsync(BarberShopForCreationDto dto);
    Task<BarberShopForResultDto> ModifyAsync(long id, BarberShopForUpdateDto dto);
    Task<IEnumerable<BarberShopForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
