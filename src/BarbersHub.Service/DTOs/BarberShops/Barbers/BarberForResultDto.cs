using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Service.DTOs.Orders.Orders;
using BarbersHub.Service.DTOs.BarberShops.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.BarberStyles;

namespace BarbersHub.Service.DTOs.BarberShops.Barbers;

public class BarberForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Gender { get; set; }
    public string Role { get; set; }
    public BarberShopForResultDto BarberShop { get; set; }
    public string Instagram { get; set; }
    public string Telegram { get; set; }
    public decimal Rating { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<OrderForResultDto> Orders { get; set; }
    public ICollection<BarberStyleForResultDto> BarberStyles { get; set; }
    public ICollection<BarberAssetForResultDto> Assets { get; set; }
    public bool IsDeleted { get; set; }
}
