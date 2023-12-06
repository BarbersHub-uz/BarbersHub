using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Domain.Entities.Assets;

public class BarberShopAsset : Asset
{
    public long BarberShopId { get; set; }
    public BarberShop BarberShop { get; set; }
}
