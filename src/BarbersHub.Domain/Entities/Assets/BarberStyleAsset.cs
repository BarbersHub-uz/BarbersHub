using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Domain.Entities.Assets;

public class BarberStyleAsset : Asset
{
    public long BarberStyleId { get; set; }
    public BarberStyle BarberStyle { get; set; }
}
