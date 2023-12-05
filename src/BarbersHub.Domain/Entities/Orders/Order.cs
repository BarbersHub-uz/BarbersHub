using BarbersHub.Domain.Commons;
using BarbersHub.Domain.Entities.Users;
using BarbersHub.Domain.Entities.Comments;
using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Domain.Entities.Orders;

public class Order : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long BarberId { get; set; }
    public Barber Barber { get; set; }
    public DateTime OrderDate { get; set; }
    public ICollection<Completed> Completeds { get; set; }
}
