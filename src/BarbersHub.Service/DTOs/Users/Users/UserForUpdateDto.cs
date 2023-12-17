using BarbersHub.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace BarbersHub.Service.DTOs.Users.Users;

public class UserForUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public GenderType Gender { get; set; }
    public Role Role { get; set; }
    public DateTime DateOfBirth { get; set; }
}
