using BarbersHub.Domain.Entities.Orders;

namespace BarbersHub.Service.DTOs.Comments.Completeds;

public class CompletedForCreationDto
{
    public long OrderId { get; set; }
    public decimal Rating { get; set; }
}
