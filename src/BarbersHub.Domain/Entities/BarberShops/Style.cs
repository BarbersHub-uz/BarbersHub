using BarbersHub.Domain.Commons;

namespace BarbersHub.Domain.Entities.BarberShops;

public class Style : Auditable
{
    public string ServiceType { get; set; }
}
