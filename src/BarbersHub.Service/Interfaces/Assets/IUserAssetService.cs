using Microsoft.AspNetCore.Http;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Service.Configurations;

namespace BarbersHub.Service.Interfaces.Assets;

public interface IUserAssetService
{
    Task<bool> RemoveAsync(long userId, long id);
    Task<UserAssetForResultDto> RetrieveByIdAsync(long userId, long id);
    Task<UserAssetForResultDto> AddAsync(long userId, IFormFile formFile);
    Task<IEnumerable<UserAssetForResultDto>> RetrieveAllAsync(long userId, PaginationParams @params);
}
