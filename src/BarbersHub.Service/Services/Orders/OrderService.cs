﻿using AutoMapper;
using BarbersHub.Data.IRepositories;
using BarbersHub.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using BarbersHub.Service.Configurations;
using BarbersHub.Domain.Entities.Orders;
using BarbersHub.Service.Interfaces.Orders;
using BarbersHub.Service.DTOs.Orders.Orders;
using BarbersHub.Service.Commons.Exceptions;

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

    public async Task<OrderForResultDto> AddAsync(OrderForCreationDto dto)
    {
        var data = await this._orderRepository
            .SelectAll()
            .Where(o => o.UserId == dto.UserId && o.BarberId == dto.BarberId && !o.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(data is not null)
            throw new BarberException(409,"Order is already exist");

        var mappedData = this._mapper.Map<Order>(dto);
        var createdData = await this._orderRepository.InsertAsync(mappedData);

        return this._mapper.Map<OrderForResultDto>(createdData);    
    }

    public async Task<OrderForResultDto> ModifyAsync(long id, OrderForUpdateDto dto)
    {
        var data = await this._orderRepository
            .SelectAll()
            .Where(o => o.Id == id && !o.IsDeleted)
            .FirstOrDefaultAsync();
        if(data is null)
            throw new BarberException(404,"Order is not found");

        var mappedData = this._mapper.Map(dto, data);
        mappedData.UpdatedAt = DateTime.UtcNow;
        await this._orderRepository.UpdateAsync(mappedData);
        return this._mapper.Map<OrderForResultDto>(mappedData);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var data = await this._orderRepository
            .SelectAll()
            .Where(o => o.Id == id && !o.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(data is null)
            throw new BarberException(404,"Order is not found");
        return await this._orderRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<OrderForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var data = await this._orderRepository
            .SelectAll()
            .Where(o => o.IsDeleted == false)
            .Include(o => o.Barber)
            //.ThenInclude(b => b.IsDeleted == false) 
            .Include(o => o.User)
            //.ThenInclude(u => u.IsDeleted == false)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();
        if (data is null)
            throw new BarberException(404,"Orders are not found");
        return this._mapper.Map<IEnumerable<OrderForResultDto>>(data);
    }

    public async Task<OrderForResultDto> RetrieveByIdAsync(long id)
    {
        var data = await this._orderRepository
            .SelectAll()
            .Where(o => o.IsDeleted == false)
            .Include(o => o.Barber)
            //.ThenInclude(b => b.IsDeleted == false)
            .Include(o => o.User)
            //.ThenInclude(u => u.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (data is null)
            throw new BarberException(404,"Order is not found");
        
        return this._mapper.Map<OrderForResultDto>(data);
    }
}
