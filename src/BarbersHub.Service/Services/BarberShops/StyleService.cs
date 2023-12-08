using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.Styles;
using BarbersHub.Data.IRepositories;
using BarbersHub.Domain.Entities.BarberShops;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Service.Exceptions;
using BarbersHub.Service.Extensions;

namespace BarbersHub.Service.Services.BarberShops;

public class StyleService : IStyleService
{
    private readonly IRepository<Style> _repository;
    private readonly IMapper _mapper;
    public StyleService(IRepository<Style> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StyleForResultDto> AddAsync(StyleForCreationDto dto)
    {
        var style = await _repository.SelectAll()
            .Where(s => s.ServiceType == dto.ServiceType && !s.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (style is not null)
            throw new BarberException(404, "style is already exist");
        var mappedStyle = _mapper.Map<Style>(dto);
        var result = await _repository.InsertAsync(mappedStyle);

        return _mapper.Map<StyleForResultDto>(result);
    }
    public async Task<IEnumerable<StyleForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var styles = await _repository.SelectAll()
            .Where(s => !s.IsDeleted)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<StyleForResultDto>>(styles);
    }

    public async Task<StyleForResultDto> RetrieveByIdAsync(long id)
    {
        var style = await _repository.SelectAll()
            .Where(s => s.Id == id && !s.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (style is null)
            throw new BarberException(404, "style is not found");

        return _mapper.Map<StyleForResultDto>(style);
    }

    public async Task<StyleForResultDto> ModifyAsync(long id, StyleForUpdateDto dto)
    {
        var style = await _repository.SelectAll()
            .Where(s => s.Id == id && !s.IsDeleted )
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (style is  null)
            throw new BarberException(409, "style is not found");

        var style2 = await _repository.SelectAll()
            .Where(s => s.ServiceType == dto.ServiceType && !s.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (style2 is not null)
            throw new BarberException(404, "style is already exist");

        style.UpdatedAt = DateTime.UtcNow;
        var mappedStyle = _mapper.Map(dto,style);

        var result = await _repository.UpdateAsync(mappedStyle);

        return _mapper.Map<StyleForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var style = await _repository
            .SelectAll()
            .Where(s => s.Id == id && !s.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (style is null)
            throw new BarberException(404, "style is not found");

        return await _repository.DeleteAsync(id);
    }

}
