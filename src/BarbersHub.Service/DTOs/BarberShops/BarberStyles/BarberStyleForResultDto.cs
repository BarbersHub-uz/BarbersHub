using BarbersHub.Service.DTOs.BarberShops.Barbers;
using BarbersHub.Service.DTOs.BarberShops.Styles;

namespace BarbersHub.Service.DTOs.BarberShops.BarberStyles;

public class BarberStyleForResultDto
{
    public long Id { get; set; } 
    public StyleForResultDto Style { get; set; }
    public BarberForResultDto Barber { get; set; }
    public bool IsDeleted { get; set; }
}
