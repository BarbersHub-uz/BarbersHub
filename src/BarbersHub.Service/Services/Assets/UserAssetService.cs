using AutoMapper;
using Microsoft.AspNetCore.Http;
using BarbersHub.Service.Helpers;
using BarbersHub.Service.Extensions;
using BarbersHub.Data.IRepositories;
using BarbersHub.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Domain.Entities.Users;
using BarbersHub.Domain.Entities.Assets;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Assets;

namespace BarbersHub.Service.Services.Assets;

public class UserAssetService : IUserAssetService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<UserAsset> _userAssetRepository;

    public UserAssetService(
        IMapper mapper,
        IRepository<User> userRepository,
        IRepository<UserAsset> userAssetRepository)
    {
        this._mapper = mapper;
        this._userRepository = userRepository;
        this._userAssetRepository = userAssetRepository;
    }

    public async Task<UserAssetForResultDto> AddAsync(long userId, IFormFile formFile)
    {
        var user = await this._userRepository
            .SelectAll()
            .Where(u => u.Id == userId && !u.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(user is null)
            throw new BarberException(404, "User is not found");

        var fileName = Guid.NewGuid().ToString("N")+Path.GetExtension(formFile.FileName);
        var rootPath = Path.Combine(EnvironmentHelper.WebRootPath, "Users","ProfilePhotos", fileName);
        using(var stream = new FileStream(rootPath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var mappedAsset = new UserAsset()
        {
            UserId = userId,
            Name = fileName,
            Path = Path.Combine("Users", "ProfilePhotos", formFile.FileName),
            Extension = Path.GetExtension(formFile.FileName),
            Size = formFile.Length,
            Type = formFile.ContentType,
            CreatedAt = DateTime.UtcNow,
        };

        var result = await this._userAssetRepository.InsertAsync(mappedAsset);

        return this._mapper.Map<UserAssetForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long userId, long id)
    {
        var user = await this._userRepository
            .SelectAll()
            .Where(u => u.Id == userId && !u.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(user is null)
            throw new BarberException(404, "User is not found");

        var userAsset = await this._userAssetRepository
            .SelectAll()
            .Where(ua => ua.Id == id && !ua.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (userAsset is null)
            throw new BarberException(404, "User Asset is not found");

        return await this._userAssetRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<UserAssetForResultDto>> RetrieveAllAsync(long userId, PaginationParams @params)
    {
        var user = await this._userRepository
            .SelectAll()
            .Where(u => u.Id == userId && !u.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(user is null)
            throw new BarberException(404, "User is not found");

        var userAssets = await this._userAssetRepository
            .SelectAll()
            .Where(a => a.UserId == userId && !a.IsDeleted)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return this._mapper.Map<IEnumerable<UserAssetForResultDto>>(userAssets);
    }

    public async Task<UserAssetForResultDto> RetrieveByIdAsync(long userId, long id)
    {
        var user = await this._userRepository
            .SelectAll()
            .Where(u => u.Id == userId && !u.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(user is null)
            throw new BarberException(404, "User is not found");

        var userAsset = await this._userAssetRepository
            .SelectAll()
            .Where(ua => ua.Id == id && !ua.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (userAsset is null)
            throw new BarberException(404, "UserAsset is not found");

        return this._mapper.Map<UserAssetForResultDto>(userAsset);
    }
}
