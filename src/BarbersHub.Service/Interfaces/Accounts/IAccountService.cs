using BarbersHub.Service.DTOs.Logins;

namespace BarbersHub.Service.Interfaces.Accounts;

public interface IAccountService
{
    public Task<string> LoginAsync(LoginDto loginDto);
}
