using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.Orders.Orders;

namespace BarbersHub.Service.Interfaces.Orders;

public interface IOrderService
{
    Task<bool> RemoveAsync(long id);
    Task<OrderForResultDto> RetrieveByIdAsync(long id);
    Task<OrderForResultDto> AddAsync(OrderForCreationDto dto);
    Task<OrderForResultDto> ModifyAsync(long id, OrderForUpdateDto dto);
    Task<IEnumerable<OrderForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
