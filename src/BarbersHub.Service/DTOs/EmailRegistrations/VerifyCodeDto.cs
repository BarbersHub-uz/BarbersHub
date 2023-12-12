namespace BarbersHub.Service.DTOs.EmailRegistrations;

public class VerifyCodeDto
{
    public string Email { get; set; }
    public string VerificationCode { get; set; }
}
