using BarbersHub.Service.DTOs.Users.Users;
using BarbersHub.Service.DTOs.BarberShops.BarberStyles;

namespace BarbersHub.Service.DTOs.Favorites.Favorites;

public class FavoriteForResultDto
{
    public long Id { get; set; }
    public BarberStyleForResultDto BarberStyle { get; set; }
    public UserForResultDto User { get; set; }
    public bool IsDeleted { get; set; }
}
