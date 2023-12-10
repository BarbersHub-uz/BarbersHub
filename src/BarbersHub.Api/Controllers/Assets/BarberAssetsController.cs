using BarbersHub.Api.Models;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Assets;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BarbersHub.Api.Controllers.Assets;

public class BarberAssetsController : BaseController
{
    private readonly IBarberAssetService _barberAssetService;

    public BarberAssetsController(IBarberAssetService barberAssetService)
    {
        this._barberAssetService = barberAssetService;
    }
    [HttpPost("{barber-id}")]
    public async Task<IActionResult> PostAsync([FromRoute(Name = "barber-id")] long id, [Required] IFormFile formFile)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._barberAssetService.AddAsync(id, formFile)
        });
    [HttpGet("{barber-id}")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromRoute(Name = "barber-id")] long barberId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._barberAssetService.RetrieveAllAsync(barberId, @params)
        });
    [HttpGet("{barber-id}/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "barber-id")] long barberId, [FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._barberAssetService.RetrieveByIdAsync(barberId, id)
        });
    [HttpDelete("{barber-id}/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "barber-id")] long barberId, [FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._barberAssetService.RemoveAsync(barberId, id)
        });
}
