using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Data.IRepositories;
using BarbersHub.Service.Exceptions;
using BarbersHub.Service.Extensions;
using BarbersHub.Service.Configurations;
using BarbersHub.Domain.Entities.BarberShops;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.BarberStyles;

namespace BarbersHub.Service.Services.BarberShops;

public class BarberStyleService : IBarberStyleService
{
    private readonly IMapper _mapper;
    private readonly IRepository<BarberStyle> _barberStyleRepository;

    public BarberStyleService(
        IMapper mapper, 
        IRepository<BarberStyle> barberStyleRepository)
    {
        this._mapper = mapper;
        this._barberStyleRepository = barberStyleRepository;
    }

    public async Task<BarberStyleForResultDto> AddAsync(BarberStyleForCreationDto dto)
    {
        var barberStyle  = await this._barberStyleRepository
            .SelectAll()
            .Where(bs => bs.BarberId == dto.BarberId && bs.StyleId == dto.StyleId && !bs.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (barberStyle is not null)
            throw new BarberException(409, "BarberStyle is already exist");

        var mapped = this._mapper.Map<BarberStyle>(dto);
            
        var result = await _barberStyleRepository.InsertAsync(mapped);

        return this._mapper.Map<BarberStyleForResultDto>(result);
    }
    public async Task<IEnumerable<BarberStyleForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var barberStyles = await this._barberStyleRepository
            .SelectAll()
            .Where(bs => !bs.IsDeleted)
            .Include(bs => bs.Barber)
            .Include(bs => bs.Style)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();
        
        return this._mapper.Map<IEnumerable<BarberStyleForResultDto>>(barberStyles);
    }
    public async Task<BarberStyleForResultDto> RetrieveByIdAsync(long id)
    {
        var barberStyle = await this._barberStyleRepository
            .SelectAll()
            .Where(bs => bs.IsDeleted == false && bs.Id == id)
            .Include(bs => bs.Style)
            .Include(bs => bs.Barber)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (barberStyle is null)
            throw new BarberException(404, "BarberStyle is not found");

        return this._mapper.Map<BarberStyleForResultDto>(barberStyle);
    }

    public async Task<BarberStyleForResultDto> ModifyAsync(long id, BarberStyleForUpdateDto dto)
    {
        var barberStyle = await this._barberStyleRepository
            .SelectAll()
            .Where(bs => bs.Id == id && !bs.IsDeleted)
            .FirstOrDefaultAsync();

        if (barberStyle is null)
            throw new BarberException(404, "BarberStyle is not found");

        var mapped = this._mapper.Map(dto, barberStyle);
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await _barberStyleRepository.UpdateAsync(mapped);

        return this._mapper.Map<BarberStyleForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var barberStyle = await this._barberStyleRepository
            .SelectAll()
            .Where(bs => bs.Id == id && !bs.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (barberStyle is  null)
            throw new BarberException(404, "BarberStyle is not found");

        return await this._barberStyleRepository.DeleteAsync(id);
    }
}
