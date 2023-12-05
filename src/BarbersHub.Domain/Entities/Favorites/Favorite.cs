using BarbersHub.Domain.Commons;
using BarbersHub.Domain.Entities.Users;
using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Domain.Entities.Favorites;

public class Favorite : Auditable
{
    public long BarberStyleId { get; set; }
    public BarberStyle BarberStyle { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
