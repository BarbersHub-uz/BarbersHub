using BarbersHub.Service.DTOs.Assets;
using BarbersHub.Service.DTOs.Comments.Comments;
using BarbersHub.Service.DTOs.Favorites.Favorites;
using BarbersHub.Service.DTOs.BarberShops.BarberStyles;

namespace BarbersHub.Service.DTOs.BarberShops.Styles;

public class StyleForResultDto
{
    public long Id { get; set; }
    public string ServiceType { get; set; }
    public decimal Cost { get; set; }
    public decimal Duration { get; set; }
    public decimal Rating { get; set; }
    public ICollection<CommentForResultDto> Comments { get; set; }
    public ICollection<StyleAssetForResultDto> Assets { get; set; }
    public ICollection<FavoriteForResultDto> Favorites { get; set; }
    public ICollection<BarberStyleForResultDto> BarberStyles { get; set; }
    public bool IsDeleted { get; set; }
}
