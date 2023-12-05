using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.Users.Users;
using BarbersHub.Service.Interfaces.Users;

namespace BarbersHub.Service.Services.Users;

public class UserService : IUserService
{
    public Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
