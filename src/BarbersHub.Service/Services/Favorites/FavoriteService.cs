using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Favorites;
using BarbersHub.Service.DTOs.Favorites.Favorites;

namespace BarbersHub.Service.Services.Favorites;

public class FavoriteService : IFavoriteService
{
    public Task<FavoriteForResultDto> AddAsync(FavoriteForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<FavoriteForResultDto> ModifyAsync(long id, FavoriteForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<FavoriteForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<FavoriteForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
