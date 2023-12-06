using Microsoft.AspNetCore.Http;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Assets;

namespace BarbersHub.Service.Services.Assets;

internal class BarberAssetService : IBarberAssetService
{
    public Task<BarberAssetForResultDto> CreateAsync(long barberId, IFormFile formFile)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long barberId, long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BarberAssetForResultDto>> RetrieveAllAsync(long barberId, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<BarberAssetForResultDto> RetrieveByIdAsync(long barberId, long id)
    {
        throw new NotImplementedException();
    }
}
