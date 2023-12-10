using BarbersHub.Domain.Entities.Comments;
using BarbersHub.Domain.Entities.Favorites;
using BarbersHub.Domain.Entities.BarberShops;
using Microsoft.AspNetCore.Http;

namespace BarbersHub.Service.DTOs.BarberShops.BarberStyles;

public class BarberStyleForCreationDto
{
    public long StyleId { get; set; }
    public long BarberId { get; set; }
}
