using BarbersHub.Domain.Commons;

namespace BarbersHub.Domain.Entities.BarberShops;

public class BarberStyle : Auditable
{
    public long StyleId { get; set; }
    public Style Style { get; set; }
    public long BarberId { get; set; }
    public Barber Barber { get; set; }
}
