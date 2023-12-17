using BarbersHub.Domain.Enums;
using BarbersHub.Domain.Commons;
using BarbersHub.Domain.Entities.Orders;
using BarbersHub.Domain.Entities.Assets;

namespace BarbersHub.Domain.Entities.BarberShops;

public class Barber : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public GenderType Gender { get; set; }
    public Role Role { get; set; }
    public long BarberShopId { get; set; }
    public BarberShop BarberShop { get; set; }
    public string Instagram { get; set; }
    public string Telegram { get; set; }
    public decimal Rating { get; set; } = 0;
    public string Salt { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<BarberStyle> BarberStyles { get; set; }
    public ICollection<BarberAsset> Assets { get; set; }
}
