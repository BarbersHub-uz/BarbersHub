using Microsoft.AspNetCore.Http;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Service.Configurations;

namespace BarbersHub.Service.Interfaces.Assets;

public interface IStyleAssetService
{
    Task<bool> RemoveAsync(long styleId, long id);
    Task<StyleAssetForResultDto> RetrieveByIdAsync(long styleId, long id);
    Task<StyleAssetForResultDto> AddAsync(long styleId, IFormFile formFile);
    Task<IEnumerable<StyleAssetForResultDto>> RetrieveAllAsync(long styleId, PaginationParams @params);
}
