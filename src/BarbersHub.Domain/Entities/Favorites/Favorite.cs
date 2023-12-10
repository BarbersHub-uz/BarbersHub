using BarbersHub.Domain.Commons;
using BarbersHub.Domain.Entities.Users;
using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Domain.Entities.Favorites;

public class Favorite : Auditable
{
    public long StyleId { get; set; }
    public Style Style { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
