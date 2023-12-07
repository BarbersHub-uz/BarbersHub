using AutoMapper;
using BarbersHub.Service.Helpers;
using BarbersHub.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Service.Exceptions;
using BarbersHub.Domain.Entities.Users;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.Users.Users;
using BarbersHub.Service.Interfaces.Users;
using BarbersHub.Service.DTOs.ChangePassword;
using BarbersHub.Service.Extensions;

namespace BarbersHub.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;

    public UserService(
        IRepository<User> userRepository,
        IMapper mapper)
    {
        this._mapper = mapper;
        this._userRepository = userRepository;
    }

    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        var user = await this._userRepository
            .SelectAll()
            .Where(u => u.UserName.ToLower() == dto.UserName.ToLower() && !u.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if(user is not null)
            throw new BarberException(409, "User is already exist");

        var data = this._mapper.Map<User>(dto);

        var HashedPassword = PasswordHelper.Hash(dto.Password);
        data.Password = HashedPassword.Hash;
        data.Salt = HashedPassword.Salt;
        data.Role = Domain.Enums.Role.User;
        var CreatedData = await this._userRepository.InsertAsync(data);

        return this._mapper.Map<UserForResultDto>(CreatedData);

    }

    public async Task<bool> ChangePasswordAsync(long id, ChangePasswordDto dto)
    {
        var data = await this._userRepository
            .SelectAll()
            .Where(e => e.Id == id && !e.IsDeleted)
            .FirstOrDefaultAsync();
        if (data == null || PasswordHelper.Verify(dto.OldPassword, data.Salt, data.Password) == false)
        {
            throw new BarberException(400, "User or Password is Incorrect");
        }
        else if (dto.NewPassword != dto.ConfirmPassword)
        {
            throw new BarberException(400, "New Password and Confirm Password does not Match");
        }
        var HashedPassword = PasswordHelper.Hash(dto.ConfirmPassword);
        data.Salt = HashedPassword.Salt;
        data.Password = HashedPassword.Hash;
        await _userRepository.UpdateAsync(data);
        return true;
    }

    public async Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
    {
        var user = await this._userRepository
            .SelectAll()
            .Where(u => u.Id == id && !u.IsDeleted)
            .FirstOrDefaultAsync();
        if(user is null)
            throw new BarberException(404, "User is not found");

        user.UpdatedAt = DateTime.UtcNow;
        var person = this._mapper.Map(dto, user);
        await this._userRepository.UpdateAsync(person);
        return this._mapper.Map<UserForResultDto>(person);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await this._userRepository
            .SelectAll()
            .Where(u => u.Id == id && !u.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(user is null)
            throw new BarberException(404, "User is not found");

        return await this._userRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var users = await this._userRepository
            .SelectAll()
            .Where(u => u.IsDeleted == false)
            .Include(u => u.Assets)
            //.Include(u => u.Comments)
            //.Include(u => u.Favorites)
            //.Include(u => u.Orders)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return this._mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        var user = await this._userRepository
            .SelectAll()
            .Where(u => u.Id == id && !u.IsDeleted)
            .Include(u => u.Assets)
            //.Include(u => u.Comments)
            //.Include(u => u.Favorites)
            //.Include(u => u.Orders)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(user is null)
            throw new BarberException(404, "User is not found");

        return this._mapper.Map<UserForResultDto>(user);
    }
}
