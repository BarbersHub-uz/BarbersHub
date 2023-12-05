
namespace BarbersHub.Service.DTOs.Orders.Orders;

public class OrderForCreationDto
{
    public long UserId { get; set; }
    public long BarberId { get; set; }
    public DateTime OrderDate { get; set; }
}
