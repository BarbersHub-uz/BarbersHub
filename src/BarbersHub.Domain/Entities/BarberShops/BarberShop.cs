using BarbersHub.Domain.Commons;
using BarbersHub.Domain.Entities.Assets;
using System.Text.Json.Serialization;

namespace BarbersHub.Domain.Entities.BarberShops;

public class BarberShop : Auditable
{
    public string Title { get; set; }
    public string OpeningHours { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public ICollection<Barber> Barbers { get; set; }
    public ICollection<BarberShopAsset> Assets { get; set; }
}
