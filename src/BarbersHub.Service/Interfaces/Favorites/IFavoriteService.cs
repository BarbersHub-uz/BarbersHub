using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.Favorites.Favorites;

namespace BarbersHub.Service.Interfaces.Favorites;

public interface IFavoriteService
{
    Task<bool> RemoveAsync(long id);
    Task<FavoriteForResultDto> RetrieveByIdAsync(long id);
    Task<FavoriteForResultDto> AddAsync(FavoriteForCreationDto dto);
    Task<FavoriteForResultDto> ModifyAsync(long id, FavoriteForUpdateDto dto);
    Task<IEnumerable<FavoriteForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
