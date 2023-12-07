using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.BarberStyles;
using BarbersHub.Data.IRepositories;
using BarbersHub.Domain.Entities.BarberShops;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Service.Exceptions;
using BarbersHub.Service.Extensions;

namespace BarbersHub.Service.Services.BarberShops;

public class BarberStyleService : IBarberStyleService
{
    private readonly IRepository<BarberStyle> _repository;
    private readonly IMapper _mapper;

    public BarberStyleService(IMapper mapper, IRepository<BarberStyle> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<BarberStyleForResultDto> AddAsync(BarberStyleForCreationDto dto)
    {
        var barberStyle  = await _repository.SelectAll()
            .Where(bs => bs.BarberId == dto.BarberId && bs.StyleId == dto.StyleId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (barberStyle is not null)
            throw new BarberException(404, "BarberStyle is already exist");

        var mapped = _mapper.Map<BarberStyle>(dto);

        var result = await _repository.InsertAsync(mapped);

        return _mapper.Map<BarberStyleForResultDto>(result);
    }

    public async Task<BarberStyleForResultDto> ModifyAsync(long id, BarberStyleForUpdateDto dto)
    {
        var barberStyle = await _repository.SelectAll()
            .Where(bs => bs.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (barberStyle is null)
            throw new BarberException(404, "BarberStyle is not found");

        var mapped = _mapper.Map<BarberStyle>(dto);

        var result = await _repository.UpdateAsync(mapped);

        return _mapper.Map<BarberStyleForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var barberStyle = await _repository.SelectAll()
            .Where(bs => bs.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (barberStyle is  null)
            throw new BarberException(404, "BarberStyle is not found");

        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<BarberStyleForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var barberStyles = await _repository.SelectAll()
            .Where(bs => bs.IsDeleted == false)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        var mappedBarberStyles = _mapper.Map<IEnumerable<BarberStyle>>(barberStyles);
        
        return _mapper.Map<IEnumerable<BarberStyleForResultDto>>(mappedBarberStyles);
    }

    public async Task<BarberStyleForResultDto> RetrieveByIdAsync(long id)
    {
        var barberStyle = await _repository.SelectAll()
            .Where(bs => bs.IsDeleted == false && bs.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (barberStyle is null)
            throw new BarberException(409, "BarberStyle is not found");

        var result = _mapper.Map<BarberStyle>(barberStyle);
        return _mapper.Map<BarberStyleForResultDto>(result);
    }
}
