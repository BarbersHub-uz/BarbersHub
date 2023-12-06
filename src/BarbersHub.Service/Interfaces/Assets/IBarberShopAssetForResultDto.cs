using Microsoft.AspNetCore.Http;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Service.Configurations;

namespace BarbersHub.Service.Interfaces.Assets;

public interface IBarberShopAssetService
{
    Task<bool> RemoveAsync(long barberShopId, long id);
    Task<BarberShopAssetForResultDto> RetrieveByIdAsync(long barberShopId, long id);
    Task<BarberShopAssetForResultDto> CreateAsync(long barberShopId, IFormFile formFile);
    Task<IEnumerable<BarberShopAssetForResultDto>> RetrieveAllAsync(long barberShopId, PaginationParams @params);
}
