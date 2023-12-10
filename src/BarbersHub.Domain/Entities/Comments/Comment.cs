using BarbersHub.Domain.Commons;
using BarbersHub.Domain.Entities.Users;
using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Domain.Entities.Comments;

public class Comment : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long StyleId { get; set; }
    public Style Style { get; set; }
}
