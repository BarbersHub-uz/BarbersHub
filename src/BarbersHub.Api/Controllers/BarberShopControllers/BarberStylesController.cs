using BarbersHub.Api.Models;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.BarberShops.BarberStyles;
using BarbersHub.Service.Interfaces.BarberShops;
using Microsoft.AspNetCore.Mvc;

namespace BarbersHub.Api.Controllers.BarberShopControllers;

public class BarberStylesController : BaseController
{
    private readonly IBarberStyleService _barberStyleService;

    public BarberStylesController(IBarberStyleService barberStyleService)
    {
        _barberStyleService = barberStyleService;
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

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody]BarberStyleForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _barberStyleService.ModifyAsync(id, dto)
        });

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "success",
            Data = await _barberStyleService.RemoveAsync(id)
        });
}
