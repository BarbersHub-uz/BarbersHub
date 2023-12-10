using BarbersHub.Api.Models;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Assets;
using BarbersHub.Service.Interfaces.BarberShops;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BarbersHub.Api.Controllers.Assets;

public class StylesAssetController : BaseController
{
    private readonly IStyleAssetService _styleAssetService;

    public StylesAssetController(IStyleAssetService styleAssetService)
    {
        this._styleAssetService = styleAssetService;
    }
    [HttpPost("{styleId}")]
    public async Task<IActionResult> PostAsync([FromRoute(Name = "styleId")] long styleId, [Required] IFormFile formFile)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._styleAssetService.AddAsync(styleId, formFile)
        });
    [HttpGet("{styleId}")]
    public async Task<IActionResult> GetAllAsync([FromRoute(Name = "styleId")] long styleId, [FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._styleAssetService.RetrieveAllAsync(styleId, @params)
        });
    [HttpGet("{styleId}/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "styleId")] long styleId, [FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._styleAssetService.RetrieveByIdAsync(styleId, id)
        });
    [HttpDelete("{styleId}/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "styleId")] long styleId, [FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._styleAssetService.RemoveAsync(styleId, id)

        });
}
