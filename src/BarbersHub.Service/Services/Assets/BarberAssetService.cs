﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using BarbersHub.Service.Helpers;
using BarbersHub.Service.Extensions;
using BarbersHub.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Service.Configurations;
using BarbersHub.Domain.Entities.Assets;
using BarbersHub.Service.Interfaces.Assets;
using BarbersHub.Service.Commons.Exceptions;

namespace BarbersHub.Service.Services.Assets;

public class BarberAssetService : IBarberAssetService
{
    private readonly IMapper _mapper;
    private readonly IBarberRepository _barberRepository;
    private readonly IBarberAssetRepository _barberAssetRepository;

    public BarberAssetService(
        IMapper mapper,
        IBarberRepository barberRepository,
        IBarberAssetRepository barberAssetRepository)
    {
        this._mapper = mapper;
        this._barberRepository = barberRepository;
        this._barberAssetRepository = barberAssetRepository;
    }

    public async Task<BarberAssetForResultDto> AddAsync(long barberId, IFormFile formFile)
    {
        var barber = await this._barberRepository
            .SelectAll()
            .Where(b => b.Id == barberId && !b.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(barber is null)
            throw new BarberException(404, "Barber is not found");

        if (formFile.Length > 5100000)
            throw new BarberException(500, "Size of file must be less than 5 mb");

        var extensionOfPhoto = Path.GetExtension(formFile.FileName);
        if(extensionOfPhoto != ".jpg" || extensionOfPhoto != ".png")
        {
            throw new BarberException(500, "Extension of photo must be .jpg, .png");
        }

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName);
        var rootPath = Path.Combine(EnvironmentHelper.WebRootPath, "Barbers", "ProfilePhotos", fileName);
        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var mappedAsset = new BarberAsset()
        {
            BarberId = barberId,
            Name = fileName,
            Path = Path.Combine("Barbers", "ProfilePhotos", formFile.FileName),
            Extension = Path.GetExtension(formFile.FileName),
            Size = formFile.Length,
            Type = formFile.ContentType,
            CreatedAt = DateTime.UtcNow,
        };

        var result = await this._barberAssetRepository.InsertAsync(mappedAsset);

        return this._mapper.Map<BarberAssetForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long barberId, long id)
    {
        var barber = await this._barberRepository
            .SelectAll()
            .Where(b => b.Id == barberId && !b.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if(barber is null)
            throw new BarberException(404,"Barber is not found");
        
        var barberAsset = await this._barberAssetRepository
            .SelectAll()
            .Where(ba => ba.Id == id && !ba.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (barberAsset is null)
            throw new BarberException(404, "BarberAsset is not found");

        return await this._barberAssetRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<BarberAssetForResultDto>> RetrieveAllAsync(long barberId, PaginationParams @params)
    {
        var barber = await this._barberRepository
            .SelectAll()
            .Where(b => b.Id == barberId && !b.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(barber is null)
            throw new BarberException(404,"Barber is not fount");

        var barberAssets = await this._barberAssetRepository
            .SelectAll()
            .Where(ba => ba.BarberId == barberId && !ba.IsDeleted)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return this._mapper.Map<IEnumerable<BarberAssetForResultDto>>(barberAssets);
    }

    public async Task<BarberAssetForResultDto> RetrieveByIdAsync(long barberId, long id)
    {
        var barber = await this._barberRepository
            .SelectAll()
            .Where(b => b.Id == barberId && !b.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(barber is null)
            throw new BarberException(404, "Barber is not found");

        var barberAsset = await this._barberAssetRepository
            .SelectAll()
            .Where(ba => ba.Id == id && !ba.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync(); 

        return this._mapper.Map<BarberAssetForResultDto>(barberAsset);
    }
}
