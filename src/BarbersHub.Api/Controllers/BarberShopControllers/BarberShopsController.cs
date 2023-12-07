using BarbersHub.Api.Models;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.BarberShops.BarberShops;
using BarbersHub.Service.DTOs.Users.Users;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace BarbersHub.Api.Controllers.BarberShopControllers;

public class BarberShopsController : BaseController
{
    private readonly IBarberShopService _shopService;

    public BarberShopsController(IBarberShopService shopService)
    {
        _shopService = shopService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] BarberShopForCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._shopService.AddAsync(dto)
        });

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._shopService.RetrieveAllAsync(@params)
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._shopService.RetrieveByIdAsync(id)
        });

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] BarberShopForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._shopService.ModifyAsync(id, dto)
        });
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._shopService.RemoveAsync(id)
        });
}
