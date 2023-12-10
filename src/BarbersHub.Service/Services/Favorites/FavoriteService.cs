using AutoMapper;
using BarbersHub.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Service.Exceptions;
using BarbersHub.Service.Extensions;
using BarbersHub.Service.Configurations;
using BarbersHub.Domain.Entities.Favorites;
using BarbersHub.Service.Interfaces.Favorites;
using BarbersHub.Service.DTOs.Favorites.Favorites;

namespace BarbersHub.Service.Services.Favorites;

public class FavoriteService : IFavoriteService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Favorite> _favoriteService;

    public FavoriteService(
        IMapper mapper,
        IRepository<Favorite> favoriteService)
    {
        this._mapper = mapper;
        this._favoriteService = favoriteService;
    }

    public async Task<FavoriteForResultDto> AddAsync(FavoriteForCreationDto dto)
    {
        var data = await this._favoriteService
            .SelectAll()
            .Where(f => f.UserId == dto.UserId && f.StyleId == dto.StyleId && !f.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(data is not null)
            throw new BarberException(409,"Favorite is already exist");

        var mappedData = this._mapper.Map<Favorite>(dto);
       
        var createdData = await this._favoriteService.InsertAsync(mappedData);
        
        return this._mapper.Map<FavoriteForResultDto>(createdData);
    }

    public async Task<FavoriteForResultDto> ModifyAsync(long id, FavoriteForUpdateDto dto)
    {
        var data = await this._favoriteService
            .SelectAll()
            .Where(f => f.Id == id && !f.IsDeleted)
            .FirstOrDefaultAsync();
        if(data is null)
            throw new BarberException(404,"Favorite is not found");

        var mappedData = this._mapper.Map(dto, data);
        mappedData.UpdatedAt = DateTime.UtcNow;

        var createdData = await this._favoriteService.UpdateAsync(mappedData);

        return this._mapper.Map<FavoriteForResultDto>(createdData);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var data = await this._favoriteService
            .SelectAll()
            .Where(f => f.Id == id && !f.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(data is null)
            throw new BarberException(404,"Barber is not found");

        return await this._favoriteService.DeleteAsync(id);
    }

    public async Task<IEnumerable<FavoriteForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var data = await this._favoriteService
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
        var data = await this._favoriteService
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
