using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Service.Exceptions;
using BarbersHub.Service.Extensions;
using BarbersHub.Data.IRepositories;
using BarbersHub.Service.Configurations;
using BarbersHub.Domain.Entities.BarberShops;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.Styles;

namespace BarbersHub.Service.Services.BarberShops;

public class StyleService : IStyleService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Style> _styleRepository;
    public StyleService(
        IMapper mapper,
        IRepository<Style> styleRepository)
    {
        _styleRepository = styleRepository;
        _mapper = mapper;
    }

    public async Task<StyleForResultDto> AddAsync(StyleForCreationDto dto)
    {
        var style = await _styleRepository
            .SelectAll()
            .Where(s => s.ServiceType.ToLower() == dto.ServiceType.ToLower()
                        && s.Cost == dto.Cost && !s.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (style is not null)
            throw new BarberException(409, "style is already exist");
        var mappedStyle = _mapper.Map<Style>(dto);
        var result = await _styleRepository.InsertAsync(mappedStyle);

        return _mapper.Map<StyleForResultDto>(result);
    }
    public async Task<IEnumerable<StyleForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var styles = await _styleRepository
            .SelectAll()
            .Where(s => !s.IsDeleted)
            .Include(s => s.Assets.Where(a => !a.IsDeleted))
            .Include(s => s.Comments.Where(c => !c.IsDeleted))
            .Include(s => s.Favorites.Where(f => !f.IsDeleted))
            .Include(s => s.BarberStyles.Where(b => !b.IsDeleted))
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<StyleForResultDto>>(styles);
    }

    public async Task<StyleForResultDto> RetrieveByIdAsync(long id)
    {
        var style = await _styleRepository
            .SelectAll()
            .Where(s => s.Id == id && !s.IsDeleted)
            .Include(s => s.Assets.Where(a => !a.IsDeleted))
            .Include(s => s.Comments.Where(c => !c.IsDeleted))
            .Include(s => s.Favorites.Where(f => !f.IsDeleted))
            .Include(s => s.BarberStyles.Where(b => !b.IsDeleted))
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (style is null)
            throw new BarberException(404, "style is not found");

        return _mapper.Map<StyleForResultDto>(style);
    }

    public async Task<StyleForResultDto> ModifyAsync(long id, StyleForUpdateDto dto)
    {
        var style = await _styleRepository
            .SelectAll()
            .Where(s => s.Id == id && !s.IsDeleted )
            .FirstOrDefaultAsync();

        if (style is  null)
            throw new BarberException(409, "style is not found");

        var mappedStyle = _mapper.Map(dto,style);
        mappedStyle.UpdatedAt = DateTime.UtcNow;

        var result = await _styleRepository.UpdateAsync(mappedStyle);

        return _mapper.Map<StyleForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var style = await _styleRepository
            .SelectAll()
            .Where(s => s.Id == id && !s.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (style is null)
            throw new BarberException(404, "style is not found");

        return await _styleRepository.DeleteAsync(id);
    }
}
