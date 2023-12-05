using BarbersHub.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace BarbersHub.Service.DTOs.BarberShops.Barbers;

public class BarberForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public GenderType Gender { get; set; }
    public IFormFile Image { get; set; }
    public long BarberShopId { get; set; }
    public string Instagram { get; set; }
    public string Telegram { get; set; }
    public decimal Rating { get; set; } = 0;
    public DateTime DateOfBirth { get; set; }
}
