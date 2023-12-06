using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Domain.Entities.Assets;

public class BarberAsset : Asset
{
    public long BarberId { get; set; }
    public Barber Barber { get; set; }
}
