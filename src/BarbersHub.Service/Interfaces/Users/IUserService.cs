using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.Users.Users;
using BarbersHub.Service.DTOs.ChangePassword;

namespace BarbersHub.Service.Interfaces.Users;

public interface IUserService
{
    Task<bool> RemoveAsync(long id);
    Task<UserForResultDto> RetrieveByIdAsync(long id);
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<bool> ChangePasswordAsync(long id, ChangePasswordDto dto);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
    Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
