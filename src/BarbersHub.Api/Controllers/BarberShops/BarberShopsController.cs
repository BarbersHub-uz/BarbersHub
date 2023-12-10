using BarbersHub.Api.Models;
using Microsoft.AspNetCore.Mvc;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.BarberShops;

namespace BarbersHub.Api.Controllers.BarberShops;

public class BarberShopsController : BaseController
{
    private readonly IBarberShopService _shopService;

    public BarberShopsController(IBarberShopService shopService)
    {
        this._shopService = shopService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] BarberShopForCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _shopService.AddAsync(dto)
        });

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _shopService.RetrieveAllAsync(@params)
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _shopService.RetrieveByIdAsync(id)
        });

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] BarberShopForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _shopService.ModifyAsync(id, dto)
        });
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _shopService.RemoveAsync(id)
        });
}
