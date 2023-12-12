using BarbersHub.Service.Interfaces.Users;
using BarbersHub.Service.DTOs.EmailRegistrations;
using BarbersHub.Service.DTOs.Users.Registrations;

namespace BarbersHub.Service.Services.Users;

public class RegistrationService : IRegistrationService
{
    public Task<RegistrationForResultDto> AddAsync(RegistrationForCreationDto dto)
    {

        throw new NotImplementedException();
    }

    public Task<string> SendVerificationCodeAsync(SendVerificationCodeDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> VerifyCodeAsync(VerifyCodeDto dto)
    {
        throw new NotImplementedException();
    }
}
