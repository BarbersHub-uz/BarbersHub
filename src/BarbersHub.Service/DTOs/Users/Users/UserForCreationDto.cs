using BarbersHub.Domain.Enums;
using BarbersHub.Service.Commons.Attributes;

namespace BarbersHub.Service.DTOs.Users.Users;

public class UserForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [StrongPasswordAttribute]
    public string Password { get; set; }
    public string UserName { get; set; }
    [PhoneNumberAttribute]
    public string PhoneNumber { get; set; }
    public GenderType Gender { get; set; }
    public Role Role { get; set; }
    public DateTime DateOfBirth { get; set; }
}
