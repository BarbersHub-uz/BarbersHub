using BarbersHub.Service.DTOs.Orders.Orders;

namespace BarbersHub.Service.DTOs.Comments.Completeds;

public class CompletedForResultDto
{
    public long Id { get; set; }
    public OrderForResultDto Order { get; set; }
    public decimal Rating { get; set; }
}
