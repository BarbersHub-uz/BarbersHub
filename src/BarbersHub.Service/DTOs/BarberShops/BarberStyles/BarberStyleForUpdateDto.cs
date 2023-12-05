using Microsoft.AspNetCore.Http;

namespace BarbersHub.Service.DTOs.BarberShops.BarberStyles;

public class BarberStyleForUpdateDto
{
    public long StyleId { get; set; }
    public long BarberId { get; set; }
    public IFormFile Image { get; set; }
    public decimal Cost { get; set; }
    public decimal Duration { get; set; }
    public decimal Rating { get; set; }
}
