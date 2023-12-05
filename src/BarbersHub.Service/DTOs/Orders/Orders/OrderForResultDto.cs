using BarbersHub.Domain.Entities.Comments;
using BarbersHub.Service.DTOs.Users.Users;
using BarbersHub.Service.DTOs.BarberShops.Barbers;
using BarbersHub.Service.DTOs.Comments.Completeds;

namespace BarbersHub.Service.DTOs.Orders.Orders;

public class OrderForResultDto
{
    public long Id { get; set; }
    public UserForResultDto User { get; set; }
    public BarberForResultDto Barber { get; set; }
    public DateTime OrderDate { get; set; }
    public ICollection<CompletedForResultDto> Completeds { get; set; }
}
