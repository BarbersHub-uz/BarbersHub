using BarbersHub.Service.Commons.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BarbersHub.Service.DTOs.Logins;

public class LoginDto
{
    [Required(ErrorMessage = "Please Enter Phone Number"), PhoneNumber]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Enter the password"), StrongPassword]
    public string Password { get; set; }
}
