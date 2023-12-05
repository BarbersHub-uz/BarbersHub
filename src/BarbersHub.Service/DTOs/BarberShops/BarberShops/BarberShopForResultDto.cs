

using BarbersHub.Service.DTOs.BarberShops.Barbers;

namespace BarbersHub.Service.DTOs.BarberShops.BarberShops;

public class BarberShopForResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string OpeningHours { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public ICollection<BarberForResultDto> Barbers { get; set; }
}
