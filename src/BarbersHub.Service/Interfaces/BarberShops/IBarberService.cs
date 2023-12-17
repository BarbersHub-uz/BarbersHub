using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.ChangePassword;
using BarbersHub.Service.DTOs.BarberShops.Barbers;

namespace BarbersHub.Service.Interfaces.BarberShops;

public interface IBarberService
{
    Task<bool> RemoveAsync(long id);
    Task<BarberForResultDto> RetrieveByIdAsync(long id);
    Task<BarberForResultDto> AddAsync(BarberForCreationDto dto);
    Task<bool> ChangePasswordAsync(long id, ChangePasswordDto dto);
    Task<BarberForResultDto> ModifyAsync(long id, BarberForUpdateDto dto);
    Task<IEnumerable<BarberForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
