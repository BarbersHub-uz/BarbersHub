using BarbersHub.Api.Models;
using Microsoft.AspNetCore.Mvc;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Orders;
using BarbersHub.Service.DTOs.Orders.Orders;

namespace BarbersHub.Api.Controllers.Orders;

public class OrdersController : BaseController
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        this._orderService = orderService;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] OrderForCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._orderService.AddAsync(dto)
        });

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._orderService.RetrieveAllAsync(@params)
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._orderService.RetrieveByIdAsync(id)
        });

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] OrderForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._orderService.ModifyAsync(id, dto)
        });

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._orderService.RemoveAsync(id)
        });
}
