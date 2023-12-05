
namespace BarbersHub.Service.DTOs.Orders.Orders;

public class OrderForUpdateDto
{
    public long UserId { get; set; }
    public long BarberId { get; set; }
    public DateTime OrderDate { get; set; }
}
