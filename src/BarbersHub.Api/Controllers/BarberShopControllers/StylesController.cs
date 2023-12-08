using BarbersHub.Api.Models;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.DTOs.BarberShops.Styles;
using BarbersHub.Service.Interfaces.BarberShops;
using Microsoft.AspNetCore.Mvc;

namespace BarbersHub.Api.Controllers.BarberShopControllers;

public class StylesController : BaseController
{
    private readonly IStyleService styleService;

    public StylesController(IStyleService styleService)
    {
        this.styleService = styleService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] StyleForCreationDto dto)
    => Ok(new Response
    {
        StatusCode = 200,
        Message = "Success",
        Data = await styleService.AddAsync(dto)
    });

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await styleService.RetrieveAllAsync(@params)
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await styleService.RetrieveByIdAsync(id)
        });

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] StyleForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await styleService.ModifyAsync(id, dto)
        });

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "success",
            Data = await styleService.RemoveAsync(id)
        });

}
