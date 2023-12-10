using BarbersHub.Service.DTOs.Users.Users;
using BarbersHub.Service.DTOs.BarberShops.Styles;

namespace BarbersHub.Service.DTOs.Comments.Comments;

public class CommentForResultDto
{
    public long Id { get; set; }
    public UserForResultDto User { get; set; }
    public StyleForResultDto Style { get; set; }
    public bool IsDeleted { get; set; }
}
