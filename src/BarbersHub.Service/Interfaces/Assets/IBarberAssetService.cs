using Microsoft.AspNetCore.Http;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Service.Configurations;

namespace BarbersHub.Service.Interfaces.Assets;

public interface IBarberAssetService
{
    Task<bool> RemoveAsync(long barberId, long id);
    Task<BarberAssetForResultDto> CreateAsync(long barberId, IFormFile formFile);
    Task<BarberAssetForResultDto> RetrieveByIdAsync(long barberId, long id);
    Task<IEnumerable<BarberAssetForResultDto>> RetrieveAllAsync(long barberId, PaginationParams @params);
}
