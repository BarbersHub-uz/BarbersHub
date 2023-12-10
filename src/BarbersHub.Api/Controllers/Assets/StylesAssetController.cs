using BarbersHub.Api.Models;
using Microsoft.AspNetCore.Mvc;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Assets;
using System.ComponentModel.DataAnnotations;

namespace BarbersHub.Api.Controllers.Assets;

public class StylesAssetController : BaseController
{
    private readonly IStyleAssetService _styleAssetService;

    public StylesAssetController(IStyleAssetService styleAssetService)
    {
        this._styleAssetService = styleAssetService;
    }
    [HttpPost("{style-id}")]
    public async Task<IActionResult> PostAsync([FromRoute(Name = "style-id")] long styleId, [Required] IFormFile formFile)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._styleAssetService.AddAsync(styleId, formFile)
        });
    [HttpGet("{style-id}")]
    public async Task<IActionResult> GetAllAsync([FromRoute(Name = "style-id")] long styleId, [FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._styleAssetService.RetrieveAllAsync(styleId, @params)
        });
    [HttpGet("{style-id}/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "style-id")] long styleId, [FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._styleAssetService.RetrieveByIdAsync(styleId, id)
        });
    [HttpDelete("{style-id}/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "style-id")] long styleId, [FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._styleAssetService.RemoveAsync(styleId, id)

        });
}
