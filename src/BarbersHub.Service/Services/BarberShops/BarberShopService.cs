using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.BarberShops;
using BarbersHub.Data.IRepositories;
using BarbersHub.Domain.Entities.BarberShops;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Service.Exceptions;
using BarbersHub.Service.Extensions;

namespace BarbersHub.Service.Services.BarberShops;

public class BarberShopService : IBarberShopService
{
    private readonly IMapper _mapper;
    private readonly IRepository<BarberShop> _repository;

    public BarberShopService(IMapper mapper, IRepository<BarberShop> repository)
    {
        _mapper = mapper;   
        _repository = repository;
    }
    public async Task<BarberShopForResultDto> AddAsync(BarberShopForCreationDto dto)
    {
        var shop = await _repository.SelectAll().
            Where(b => b.IsDeleted == false && 
            b.Title.ToLower() == dto.Title.ToLower() &&
            b.Location.ToLower() == dto.Location.ToLower()).
            AsNoTracking()
            .FirstOrDefaultAsync();

        if (shop is not null)
            throw new BarberException(409, "BarberShop is already exist");

        var mapped = _mapper.Map<BarberShop>(dto);

        var result = await _repository.InsertAsync(mapped);

        return _mapper.Map<BarberShopForResultDto>(result);
    }

    public async Task<BarberShopForResultDto> ModifyAsync(long id, BarberShopForUpdateDto dto)
    {
        var shop = await _repository.SelectAll().
            Where(b => b.IsDeleted == false && b.Id == id).
            FirstOrDefaultAsync();

        if (shop is null)
            throw new BarberException(404, "BarberShop is not found");

        var mapped = _mapper.Map(dto, shop);
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await _repository.UpdateAsync(mapped);

        return _mapper.Map<BarberShopForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var shop = await _repository.SelectAll().
            Where(b => b.IsDeleted == false && b.Id == id).
            FirstOrDefaultAsync();

        if (shop is null)
            throw new BarberException(404, "BarberShop is not found");

        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<BarberShopForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var shops = await _repository.SelectAll().
            Where(sh => sh.IsDeleted == false).
            ToPagedList(@params).
            AsNoTracking().
            ToListAsync();

        return _mapper.Map<IEnumerable<BarberShopForResultDto>>(shops);
    }

    public async Task<BarberShopForResultDto> RetrieveByIdAsync(long id)
    {
        var shop = await _repository.SelectAll().
            Where(b => b.IsDeleted == false && b.Id == id).
            AsNoTracking().
            FirstOrDefaultAsync();

        if (shop is null)
            throw new BarberException(404, "BarberShop is not found");

        return _mapper.Map<BarberShopForResultDto>(shop);
    }
}
