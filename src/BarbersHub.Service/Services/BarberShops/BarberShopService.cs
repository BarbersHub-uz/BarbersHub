using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Data.IRepositories;
using BarbersHub.Service.Extensions;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Commons.Exceptions;
using BarbersHub.Domain.Entities.BarberShops;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.BarberShops;

namespace BarbersHub.Service.Services.BarberShops;

public class BarberShopService : IBarberShopService
{
    private readonly IMapper _mapper;
    private readonly IBarberShopRepository _barberShopRepository;

    public BarberShopService(
        IMapper mapper, 
        IBarberShopRepository barberShopRepository)
    {
        this._mapper = mapper;   
        this._barberShopRepository = barberShopRepository;
    }
    public async Task<BarberShopForResultDto> AddAsync(BarberShopForCreationDto dto)
    {
        var shop = await this._barberShopRepository
            .SelectAll()
            .Where(b => b.IsDeleted == false && b.Title.ToLower() == dto.Title.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (shop is not null)
            throw new BarberException(409, "BarberShop is already exist");

        var mapped = this._mapper.Map<BarberShop>(dto);

        var result = await this._barberShopRepository.InsertAsync(mapped);

        return this._mapper.Map<BarberShopForResultDto>(result);
    }

    public async Task<BarberShopForResultDto> ModifyAsync(long id, BarberShopForUpdateDto dto)
    {
        var shop = await this._barberShopRepository
            .SelectAll()
            .Where(b => b.IsDeleted == false && b.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (shop is null)
            throw new BarberException(404, "BarberShop is not found");

        var mapped = this._mapper.Map(dto, shop);
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await this._barberShopRepository.UpdateAsync(mapped);

        return this._mapper.Map<BarberShopForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var shop = await this._barberShopRepository
            .SelectAll()
            .Where(b => b.IsDeleted == false && b.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (shop is null)
            throw new BarberException(404, "BarberShop is not found");

        return await this._barberShopRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<BarberShopForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var shops = await this._barberShopRepository
            .SelectAll()
            .Where(b => b.IsDeleted == false)
            .Include(b => b.Assets.Where(a => !a.IsDeleted))
            //.Include(b => b.Barbers.Where(b => !b.IsDeleted))
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return this._mapper.Map<IEnumerable<BarberShopForResultDto>>(shops);
    }

    public async Task<BarberShopForResultDto> RetrieveByIdAsync(long id)
    {
        var shop = await this._barberShopRepository
            .SelectAll()
            .Where(b => b.IsDeleted == false && b.Id == id)
            .Include(b => b.Assets.Where(a => !a.IsDeleted))
            //.Include(b => b.Barbers.Where(b => !b.IsDeleted))
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (shop is null)
            throw new BarberException(404, "BarberShop is not found");

        return this._mapper.Map<BarberShopForResultDto>(shop);
    }
}
