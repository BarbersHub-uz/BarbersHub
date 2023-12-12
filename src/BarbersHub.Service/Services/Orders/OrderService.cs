using AutoMapper;
using BarbersHub.Data.IRepositories;
using BarbersHub.Domain.Entities.Orders;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Orders;
using BarbersHub.Service.DTOs.Orders.Orders;

namespace BarbersHub.Service.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Order> _orderRepository;

    public OrderService(
        IMapper mapper,
        IRepository<Order> orderRepository)
    {
        this._mapper = mapper;
        this._orderRepository = orderRepository;
    }

    public Task<OrderForResultDto> AddAsync(OrderForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<OrderForResultDto> ModifyAsync(long id, OrderForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<OrderForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
