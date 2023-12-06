using Microsoft.AspNetCore.Http;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Assets;

namespace BarbersHub.Service.Services.Assets;

public class UserAssetService : IUserAssetService
{
    public Task<UserAssetForResultDto> CreateAsync(long userId, IFormFile formFile)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long userId, long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserAssetForResultDto>> RetrieveAllAsync(long userId, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<UserAssetForResultDto> RetrieveByIdAsync(long userId, long id)
    {
        throw new NotImplementedException();
    }
}
