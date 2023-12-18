using AutoMapper;
using Microsoft.AspNetCore.Http;
using BarbersHub.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Data.IRepositories;
using BarbersHub.Service.Extensions;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Service.Configurations;
using BarbersHub.Domain.Entities.Assets;
using BarbersHub.Service.Interfaces.Assets;
using BarbersHub.Service.Commons.Exceptions;

namespace BarbersHub.Service.Services.Assets;

public class StyleAssetService : IStyleAssetService
{
    private readonly IMapper _mapper;
    private readonly IStyleRepository _styleRepository;
    private readonly IStyleAssetRepository _styleAssetRepository;

    public StyleAssetService(
        IMapper mapper,
        IStyleRepository styleRepository,
        IStyleAssetRepository styleAssetRepository)
    {
        this._mapper = mapper;
        this._styleRepository = styleRepository;
        this._styleAssetRepository = styleAssetRepository;
    }

    public async Task<StyleAssetForResultDto> AddAsync(long styleId, IFormFile formFile)
    {
        var style = await this._styleRepository
           .SelectAll()
           .Where(u => u.Id == styleId && !u.IsDeleted)
           .AsNoTracking()
           .FirstOrDefaultAsync();
        if (style is null)
            throw new BarberException(404, "Style is not found");

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName);
        var rootPath = Path.Combine(EnvironmentHelper.WebRootPath, "Styles", "Photos", fileName);
        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var mappedAsset = new StyleAsset()
        {
            StyleId = styleId,
            Name = fileName,
            Path = Path.Combine("Styles", "Photos", formFile.FileName),
            Extension = Path.GetExtension(formFile.FileName),
            Size = formFile.Length,
            Type = formFile.ContentType,
            CreatedAt = DateTime.UtcNow,
        };

        var result = await this._styleAssetRepository.InsertAsync(mappedAsset);

        return this._mapper.Map<StyleAssetForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long styleId, long id)
    {
        var user = await this._styleRepository
            .SelectAll()
            .Where(u => u.Id == styleId && !u.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (user is null)
            throw new BarberException(404, "Style is not found");

        var styleAsset = await this._styleAssetRepository
            .SelectAll()
            .Where(ua => ua.Id == id && !ua.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (styleAsset is null)
            throw new BarberException(404, "Style Asset is not found");

        return await this._styleAssetRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<StyleAssetForResultDto>> RetrieveAllAsync(long styleId, PaginationParams @params)
    {
        var style = await this._styleRepository
           .SelectAll()
           .Where(u => u.Id == styleId && !u.IsDeleted)
           .AsNoTracking()
           .FirstOrDefaultAsync();
        if (style is null)
            throw new BarberException(404, "Style is not found");

        var styleAssets = await this._styleAssetRepository
            .SelectAll()
            .Where(a => a.StyleId == styleId && !a.IsDeleted)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return this._mapper.Map<IEnumerable<StyleAssetForResultDto>>(styleAssets);
    }

    public async Task<StyleAssetForResultDto> RetrieveByIdAsync(long styleId, long id)
    {
        var style = await this._styleRepository
            .SelectAll()
            .Where(u => u.Id == styleId && !u.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (style is null)
            throw new BarberException(404, "Style is not found");

        var styleAsset = await this._styleAssetRepository
            .SelectAll()
            .Where(ua => ua.Id == id && !ua.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (styleAsset is null)
            throw new BarberException(404, "Style Asset is not found");

        return this._mapper.Map<StyleAssetForResultDto>(styleAsset);
    }
}
