using BarbersHub.Service.DTOs.EmailRegistrations;
using BarbersHub.Service.DTOs.Users.Registrations;

namespace BarbersHub.Service.Interfaces.Users;

public interface IRegistrationService
{
    Task<bool> VerifyCodeAsync(VerifyCodeDto dto);
    Task<string> SendVerificationCodeAsync(SendVerificationCodeDto dto);
    Task<RegistrationForResultDto> AddAsync(RegistrationForCreationDto dto);
}
