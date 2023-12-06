using Microsoft.AspNetCore.Http;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Assets;

namespace BarbersHub.Service.Services.Assets;

public class BarberStyleAssetService : IBarberStyleAssetService
{
    public Task<BarberStyleAssetForResultDto> CreateAsync(long barberStyleId, IFormFile formFile)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long barberStyleId, long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BarberStyleAssetForResultDto>> RetrieveAllAsync(long barberStyleId, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<BarberStyleAssetForResultDto> RetrieveByIdAsync(long barberStyleId, long id)
    {
        throw new NotImplementedException();
    }
}
