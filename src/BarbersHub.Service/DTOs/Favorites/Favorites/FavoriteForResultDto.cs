using BarbersHub.Service.DTOs.Users.Users;
using BarbersHub.Service.DTOs.BarberShops.BarberStyles;
using BarbersHub.Service.DTOs.BarberShops.Styles;

namespace BarbersHub.Service.DTOs.Favorites.Favorites;

public class FavoriteForResultDto
{
    public long Id { get; set; }
    public UserForResultDto User { get; set; }
    public StyleForResultDto Style { get; set; }
    public bool IsDeleted { get; set; }
}
