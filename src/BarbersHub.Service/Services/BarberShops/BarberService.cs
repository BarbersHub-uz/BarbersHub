using AutoMapper;
using BarbersHub.Service.Helpers;
using BarbersHub.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Service.Extensions;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Commons.Exceptions;
using BarbersHub.Domain.Entities.BarberShops;
using BarbersHub.Service.DTOs.ChangePassword;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.Barbers;

namespace BarbersHub.Service.Services.BarberShops;

public class BarberService : IBarberService
{
    private readonly IMapper _mapper;
    private readonly IBarberRepository _barberRepository;
    private readonly IBarberShopRepository _barberShopRepository;

    public BarberService(
        IMapper mapper,
        IBarberRepository barberRepository,
        IBarberShopRepository barberShopRepository)
    {
        this._mapper = mapper;
        this._barberRepository = barberRepository;
        this._barberShopRepository = barberShopRepository;
    }

    public async Task<BarberForResultDto> AddAsync(BarberForCreationDto dto)
    {
        var barberShopData = await this._barberShopRepository
            .SelectAll()
            .Where(bs => bs.Id == dto.BarberShopId && !bs.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (barberShopData is null)
            throw new BarberException(404, "BarberShop is not found");

        var barber = await this._barberRepository
            .SelectAll()
            .Where(b => b.UserName.ToLower() == dto.UserName.ToLower() && !b.IsDeleted)
            .FirstOrDefaultAsync();
        if(barber is not null)
            throw new BarberException(409, "Barber is already exist");

        var data = this._mapper.Map<Barber>(dto);

        var hashedPassword = PasswordHelper.Hash(dto.Password);
        data.Password = hashedPassword.Hash;
        data.Salt = hashedPassword.Salt;
        data.Role = Domain.Enums.Role.Barber;

        var createdData = await this._barberRepository.InsertAsync(data);

        return this._mapper.Map<BarberForResultDto>(createdData);
    }

    public async Task<BarberForResultDto> ModifyAsync(long id, BarberForUpdateDto dto)
    {
        var barberShopData = await this._barberShopRepository
            .SelectAll()
            .Where(bs => bs.Id == dto.BarberShopId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (barberShopData is null)
            throw new BarberException(404, "BarberShop is not found");

        var barber = await this._barberRepository
            .SelectAll()
            .Where(b => b.Id == id && !b.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(barber is null)
           throw new BarberException(404,"Barber is not found");

        var mappedBarber = this._mapper.Map(dto, barber);
        mappedBarber.UpdatedAt = DateTime.UtcNow;
        await this._barberRepository.UpdateAsync(mappedBarber);
        return this._mapper.Map<BarberForResultDto>(mappedBarber);
    }
    public async Task<bool> ChangePasswordAsync(long id, ChangePasswordDto dto)
    {
        var data = await this._barberRepository
            .SelectAll()
            .Where(e => e.Id == id && !e.IsDeleted)
            .FirstOrDefaultAsync();
        if (data == null || PasswordHelper.Verify(dto.OldPassword, data.Salt, data.Password) == false)
        {
            throw new BarberException(400, "Barber or Password is Incorrect");
        }
        else if (dto.NewPassword != dto.ConfirmPassword)
        {
            throw new BarberException(400, "New Password and Confirm Password does not Match");
        }
        var HashedPassword = PasswordHelper.Hash(dto.ConfirmPassword);
        data.Salt = HashedPassword.Salt;
        data.Password = HashedPassword.Hash;
        await this._barberRepository.UpdateAsync(data);
        return true;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var barber = await this._barberRepository
            .SelectAll()
            .Where(b => b.Id == id && !b.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(barber is null)
            throw new BarberException(404,"Barber is not found");

        return await this._barberRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<BarberForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var barbers = await this._barberRepository
            .SelectAll()
            .Where(b => b.IsDeleted == false)
            .Include(b => b.Assets.Where(a => !a.IsDeleted))
            .Include(b => b.BarberShop)
            .Include(b => b.BarberStyles.Where(b => b.IsDeleted == false))
            //.Include(b => b.Orders)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();
            
        var result = this._mapper.Map<IEnumerable<BarberForResultDto>>(barbers);
        foreach(var barber in result)
        {
            barber.Role = barber.Role.ToString();
            barber.Gender = barber.Gender.ToString();   
        }
        return result;
    }

    public async Task<BarberForResultDto> RetrieveByIdAsync(long id)
    {
        var barber = await this._barberRepository
            .SelectAll()
            .Where(b => b.Id == id && !b.IsDeleted)
            .Include(b => b.Assets.Where(a => !a.IsDeleted))
            .Include(b => b.Orders.Where(o => o.IsDeleted == false))
            //.Include(b => b.BarberStyles)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(barber is null)
            throw new BarberException(404,"Barber is not found");

        var result = this._mapper.Map<BarberForResultDto>(barber);
        result.Role = barber.Role.ToString();
        result.Gender = barber.Gender.ToString();
        return result;
    }
}
