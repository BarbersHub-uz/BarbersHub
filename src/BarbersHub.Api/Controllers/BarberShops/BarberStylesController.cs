using BarbersHub.Api.Models;
using Microsoft.AspNetCore.Mvc;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.BarberShops;
using BarbersHub.Service.DTOs.BarberShops.BarberStyles;

namespace BarbersHub.Api.Controllers.BarberShops;

public class BarberStylesController : BaseController
{
    private readonly IBarberStyleService _barberStyleService;

    public BarberStylesController(IBarberStyleService barberStyleService)
    {
        this._barberStyleService = barberStyleService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] BarberStyleForCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _barberStyleService.AddAsync(dto)
        });

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _barberStyleService.RetrieveAllAsync(@params)
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _barberStyleService.RetrieveByIdAsync(id)
        });

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] BarberStyleForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _barberStyleService.ModifyAsync(id, dto)
        });

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "success",
            Data = await _barberStyleService.RemoveAsync(id)
        });
}
