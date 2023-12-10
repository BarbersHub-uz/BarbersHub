using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Domain.Entities.Assets;

public class StyleAsset : Asset
{
    public long StyleId { get; set; }
    public Style Style { get; set; }
}
