using BarbersHub.Domain.Enums;
using BarbersHub.Domain.Commons;
using BarbersHub.Domain.Entities.Orders;
using BarbersHub.Domain.Entities.Comments;
using BarbersHub.Domain.Entities.Favorites;

namespace BarbersHub.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string Salt { get; set; }
    public GenderType Gender { get; set; }
    public Role Role { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<Favorite> Favorites { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Order> Orders { get; set; }
}
