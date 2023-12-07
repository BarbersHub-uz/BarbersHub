
using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Service.DTOs.BarberShops.Barbers;
using BarbersHub.Service.DTOs.BarberShops.Styles;
using BarbersHub.Service.DTOs.Comments.Comments;
using BarbersHub.Service.DTOs.Favorites.Favorites;

namespace BarbersHub.Service.DTOs.BarberShops.BarberStyles;

public class BarberStyleForResultDto
{
    public long Id { get; set; }    
    public StyleForResultDto Style { get; set; }
    public BarberStyleForResultDto Barber { get; set; }
    public decimal Cost { get; set; }
    public decimal Duration { get; set; }
    public decimal Rating { get; set; }
    public ICollection<CommentForResultDto> Comments { get; set; }
    public ICollection<FavoriteForResultDto> Favorites { get; set; }
    public ICollection<BarberStyleAssetForResultDto> BarberStyleAssets { get; set; }
}
