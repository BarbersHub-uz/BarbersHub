using BarbersHub.Domain.Entities.Users;

namespace BarbersHub.Service.Interfaces.AuthServices;

public interface IAuthService
{
    public string GenerateToken(User users);
}
