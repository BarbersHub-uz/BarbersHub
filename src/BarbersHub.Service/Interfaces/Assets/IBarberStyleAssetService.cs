using Microsoft.AspNetCore.Http;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Service.Configurations;

namespace BarbersHub.Service.Interfaces.Assets;

public interface IBarberStyleAssetService
{
    Task<bool> RemoveAsync(long barberStyleId, long id);
    Task<BarberStyleAssetForResultDto> RetrieveByIdAsync(long barberStyleId, long id);
    Task<BarberStyleAssetForResultDto> CreateAsync(long barberStyleId, IFormFile formFile);
    Task<IEnumerable<BarberStyleAssetForResultDto>> RetrieveAllAsync(long barberStyleId, PaginationParams @params);
}
