using AutoMapper;
using Microsoft.AspNetCore.Http;
using BarbersHub.Service.Helpers;
using BarbersHub.Data.IRepositories;
using BarbersHub.Service.Extensions;
using BarbersHub.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Domain.Entities.Assets;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Assets;
using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Service.Services.Assets;

public class BarberShopAssetService : IBarberShopAssetService
{
    private readonly IMapper _mapper;
    private readonly IRepository<BarberShop> _barberShopRepository;
    private readonly IRepository<BarberShopAsset> _barberShopAssetRepository;

    public BarberShopAssetService(
        IMapper mapper,
        IRepository<BarberShop> barberShopRepository,
        IRepository<BarberShopAsset> barberShopAssetRepository
        )
    {
        this._mapper = mapper;
        this._barberShopRepository = barberShopRepository;
        this._barberShopAssetRepository = barberShopAssetRepository;
    }
    public async Task<BarberShopAssetForResultDto> AddAsync(long barberShopId, IFormFile formFile)
    {
        var shop = await this._barberShopRepository
            .SelectAll()
            .Where(s => s.IsDeleted == false && s.Id == barberShopId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (shop is null)
            throw new BarberException(404, "BarberShop is not found");

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName);
        var rootPath = Path.Combine(EnvironmentHelper.WebRootPath, "BarberShops", "ProfilePhotos", fileName);
        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var mappedAsset = new BarberShopAsset()
        {
            BarberShopId = barberShopId,
            Name = fileName,
            Path = Path.Combine("BarberShops", "ProfilePhotos", formFile.FileName),
            Extension = Path.GetExtension(formFile.FileName),
            Size = formFile.Length,
            Type = formFile.ContentType,
            CreatedAt = DateTime.UtcNow,
        };

        var result = await this._barberShopAssetRepository.InsertAsync(mappedAsset);

        return this._mapper.Map<BarberShopAssetForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long barberShopId, long id)
    {
        var shop = await this._barberShopRepository
            .SelectAll()
            .Where(s => s.IsDeleted == false && s.Id == barberShopId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (shop is null)
            throw new BarberException(404, "BarberShop is not found");

        var barberShopAsset = await this._barberShopAssetRepository
            .SelectAll()
            .Where(ba => ba.Id == id && !ba.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (barberShopAsset is null)
            throw new BarberException(404, "BarberShop Asset is not found");

        return await this._barberShopAssetRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<BarberShopAssetForResultDto>> RetrieveAllAsync(long barberShopId, PaginationParams @params)
    {
        var shop = await this._barberShopRepository
            .SelectAll()
            .Where(s => s.IsDeleted == false && s.Id == barberShopId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (shop is null)
            throw new BarberException(404, "BarberShop is not found");

        var barberShopAsset = await this._barberShopAssetRepository
            .SelectAll()
            .Where(ba => ba.BarberShopId == barberShopId && !ba.IsDeleted)
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return this._mapper.Map<IEnumerable<BarberShopAssetForResultDto>>(barberShopAsset);

    }

    public async Task<BarberShopAssetForResultDto> RetrieveByIdAsync(long barberShopId, long id)
    {
        var shop = await this._barberShopRepository
            .SelectAll()
            .Where(s => s.IsDeleted == false && s.Id == barberShopId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (shop is null)
            throw new BarberException(404, "BarberShop is not found");

        var barberShopAsset = await this._barberShopAssetRepository
            .SelectAll()
            .Where(ba => ba.Id == id && !ba.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (barberShopAsset is null)
            throw new BarberException(404, "BarberShop Asset is not found");

        return this._mapper.Map<BarberShopAssetForResultDto>(barberShopAsset);
    }
}
