using BarbersHub.Domain.Commons;
using BarbersHub.Domain.Entities.Assets;
using BarbersHub.Domain.Entities.Comments;
using BarbersHub.Domain.Entities.Favorites;

namespace BarbersHub.Domain.Entities.BarberShops;

public class Style : Auditable
{
    public string ServiceType { get; set; }
    public decimal Cost { get; set; }
    public decimal Duration { get; set; }
    public decimal Rating { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<StyleAsset> Assets { get; set; }
    public ICollection<Favorite> Favorites { get; set; }
    public ICollection<BarberStyle> BarberStyles { get; set; }
}
