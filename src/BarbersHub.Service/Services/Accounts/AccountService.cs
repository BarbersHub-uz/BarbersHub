using BarbersHub.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Data.IRepositories;
using BarbersHub.Service.DTOs.Logins;
using BarbersHub.Domain.Entities.Users;
using BarbersHub.Service.Commons.Exceptions;
using BarbersHub.Service.Interfaces.Accounts;
using BarbersHub.Service.Interfaces.AuthServices;

namespace BarbersHub.Service.Services.Accounts;

public class AccountService : IAccountService
{
    private readonly IAuthService _authService;
    private readonly IRepository<User> _userRepository;

    public AccountService(IRepository<User> userRepository, IAuthService authService)
    {
        this._authService = authService;
        this._userRepository = userRepository;
    }
    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var user = await this._userRepository
            .SelectAll()
            .Where(u => u.PhoneNumber == loginDto.PhoneNumber && !u.IsDeleted)
            .FirstOrDefaultAsync();
        if (user is null)
            throw new BarberException(404, "PhoneNumber or Password ir incorrect!");

        var hasherResult = PasswordHelper.Verify(loginDto.Password, user.Salt, user.Password);
        if (hasherResult == false)
            throw new BarberException(404, "PhoneNumber or Password was entered incorrectly");

        return _authService.GenerateToken(user);
    }
}
