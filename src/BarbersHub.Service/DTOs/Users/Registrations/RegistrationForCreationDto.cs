using BarbersHub.Service.Commons.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BarbersHub.Service.DTOs.Users.Registrations;

public class RegistrationForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [PhoneNumberAttribute]
    public string PhoneNumber { get; set; }
    [StrongPasswordAttribute]
    public string Password { get; set; }
    [EmailAddress]
    public string EmailAddress { get; set; }
    public string VerificationCode { get; set; }
}
