using BarbersHub.Api.Models;
using Microsoft.AspNetCore.Mvc;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.Barbers;

namespace BarbersHub.Api.Controllers.BarberShops;

public class BarbersController : BaseController
{
    private readonly IBarberService _barberService;

    public BarbersController(IBarberService barberService)
    {
        this._barberService = barberService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] BarberForCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._barberService.AddAsync(dto)
        });

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._barberService.RetrieveAllAsync(@params)

        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._barberService.RetrieveByIdAsync(id)
        });
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] BarberForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._barberService.ModifyAsync(id, dto)

        });
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._barberService.RemoveAsync(id)
        });
}
