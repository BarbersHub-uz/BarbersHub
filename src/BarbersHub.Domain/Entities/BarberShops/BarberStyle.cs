using BarbersHub.Domain.Commons;
using BarbersHub.Domain.Entities.Assets;
using BarbersHub.Domain.Entities.Comments;
using BarbersHub.Domain.Entities.Favorites;

namespace BarbersHub.Domain.Entities.BarberShops;

public class BarberStyle : Auditable
{
    public long StyleId { get; set; }
    public Style Style { get; set; }
    public long BarberId { get; set; }
    public Barber Barber { get; set; }
    public decimal Cost { get; set; }
    public decimal Duration { get; set; }
    public decimal Rating { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Favorite> Favorites { get; set; }
    public ICollection<BarberStyleAsset> Assets { get; set; }
}
