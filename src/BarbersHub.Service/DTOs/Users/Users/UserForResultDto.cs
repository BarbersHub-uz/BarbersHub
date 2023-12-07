using BarbersHub.Domain.Enums;
using BarbersHub.Service.DTOs.Orders.Orders;
using BarbersHub.Service.DTOs.Comments.Comments;
using BarbersHub.Service.DTOs.Favorites.Favorites;
using BarbersHub.Service.DTOs.Assets;

namespace BarbersHub.Service.DTOs.Users.Users;

public class UserForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string Gender { get; set; }
    public string Role { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<FavoriteForResultDto> Favorites { get; set; }
    public ICollection<CommentForResultDto> Comments { get; set; }
    public ICollection<OrderForResultDto> Orders { get; set; }
    public ICollection<UserAssetForResultDto> UserAssets { get; set; }
    public bool IsDeleted { get; set; }
}
