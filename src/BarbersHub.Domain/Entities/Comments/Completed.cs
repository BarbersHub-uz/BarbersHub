using BarbersHub.Domain.Commons;
using BarbersHub.Domain.Entities.Orders;

namespace BarbersHub.Domain.Entities.Comments;

public class Completed : Auditable
{
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public decimal Rating { get; set; }
}
