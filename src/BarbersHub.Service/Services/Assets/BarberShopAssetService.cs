using Microsoft.AspNetCore.Http;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Assets;

namespace BarbersHub.Service.Services.Assets;

internal class BarberShopAssetService : IBarberShopAssetService
{
    public Task<BarberShopAssetForResultDto> CreateAsync(long barberShopId, IFormFile formFile)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long barberShopId, long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BarberShopAssetForResultDto>> RetrieveAllAsync(long barberShopId, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<BarberShopAssetForResultDto> RetrieveByIdAsync(long barberShopId, long id)
    {
        throw new NotImplementedException();
    }
}
