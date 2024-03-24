using AutoMapper;
using BarbersHub.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Service.Extensions;
using BarbersHub.Service.Configurations;
using BarbersHub.Domain.Entities.Favorites;
using BarbersHub.Service.Commons.Exceptions;
using BarbersHub.Service.Interfaces.Favorites;
using BarbersHub.Service.DTOs.Favorites.Favorites;

namespace BarbersHub.Service.Services.Favorites;

public class FavoriteService : IFavoriteService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IStyleRepository _styleRepository;
    private readonly IFavoriteRepository _favoriteRepository;

    public FavoriteService(
        IMapper mapper,
        IUserRepository userRepository,
        IStyleRepository styleRepository,
        IFavoriteRepository favoriteRepository)
    {
        this._mapper = mapper;
        this._userRepository = userRepository;
        this._styleRepository = styleRepository;
        this._favoriteRepository = favoriteRepository;
    }

    public async Task<FavoriteForResultDto> AddAsync(FavoriteForCreationDto dto)
    {
        var userData = await this._userRepository
            .SelectAll()
            .Where(u => u.Id == dto.UserId && !u.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (userData is null)
            throw new BarberException(404, "User is not found");

        var styleData = await this._styleRepository
            .SelectAll()
            .Where(s => s.Id == dto.StyleId && !s.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (styleData is null)
            throw new BarberException(404, "Style is not found");

        var mappedData = this._mapper.Map<Favorite>(dto);
       
        var createdData = await this._favoriteRepository.InsertAsync(mappedData);
        
        return this._mapper.Map<FavoriteForResultDto>(createdData);
    }

    public async Task<FavoriteForResultDto> ModifyAsync(long id, FavoriteForUpdateDto dto)
    {
        var data = await this._favoriteRepository
            .SelectAll()
            .Where(f => f.Id == id && !f.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(data is null)
            throw new BarberException(404,"Favorite is not found");

        var userData = await this._userRepository
            .SelectAll()
            .Where(u => u.Id == dto.UserId && !u.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (userData is null)
            throw new BarberException(404, "User is not found");

        var styleData = await this._styleRepository
            .SelectAll()
            .Where(s => s.Id == dto.StyleId && !s.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (styleData is null)
            throw new BarberException(404, "Style is not found");

        var mappedData = this._mapper.Map(dto, data);
        mappedData.UpdatedAt = DateTime.UtcNow;

        var createdData = await this._favoriteRepository.UpdateAsync(mappedData);

        return this._mapper.Map<FavoriteForResultDto>(createdData);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var data = await this._favoriteRepository
            .SelectAll()
            .Where(f => f.Id == id && !f.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(data is null)
            throw new BarberException(404,"Barber is not found");

        return await this._favoriteRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<FavoriteForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var data = await this._favoriteRepository
            .SelectAll()
            .Where(f => f.IsDeleted == false)
            .Include(f => f.User)
            .Include( f => f.Style)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();
        
        return this._mapper.Map<IEnumerable<FavoriteForResultDto>>(data);
    }

    public async Task<FavoriteForResultDto> RetrieveByIdAsync(long id)
    {
        var data = await this._favoriteRepository
            .SelectAll()
            .Where(f => f.Id == id && !f.IsDeleted)
            .Include(f => f.User)
            .Include(f => f.Style)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(data is null)
            throw new BarberException(404,"Barber is not found");

        return this._mapper.Map<FavoriteForResultDto>(data);
    }
}
