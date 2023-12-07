using BarbersHub.Api.Models;
using BarbersHub.Domain.Entities.BarberShops;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Assets;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BarbersHub.Api.Controllers.Assets;

public class BarberShopAssetsController : BaseController
{
    private readonly IBarberShopAssetService _assetService;

    public BarberShopAssetsController(IBarberShopAssetService assetService)
    {
        _assetService = assetService;
    }
    [HttpPost("{barberShop-id}")]
    public async Task<IActionResult> PostAsync([FromRoute(Name = "barberShop-id")] long barberShopId, [Required] IFormFile formFile)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._assetService.CreateAsync(barberShopId, formFile)
        });

    [HttpGet("{barberShop-id}")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromRoute(Name = "barberShop-id")] long barberShopId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._assetService.RetrieveAllAsync(barberShopId, @params)
        });

    [HttpGet("{barberShop-id}/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "barberShop-id")] long userId, [FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._assetService.RetrieveByIdAsync(userId, id)

        });

    [HttpDelete("{barberShop-id}/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "barberShop-id")] long barberShopId, [FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._assetService.RemoveAsync(barberShopId, id)
        });

}
