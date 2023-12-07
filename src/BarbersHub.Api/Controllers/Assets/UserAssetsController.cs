using BarbersHub.Api.Models;
using Microsoft.AspNetCore.Mvc;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Assets;
using System.ComponentModel.DataAnnotations;

namespace BarbersHub.Api.Controllers.Assets;

public class UserAssetsController : BaseController
{
    private readonly IUserAssetService _userAssetService;

    public UserAssetsController(IUserAssetService userAssetService)
    {
        this._userAssetService = userAssetService;
    }

    [HttpPost("{user-id}")]
    public async Task<IActionResult> PostAsync([FromRoute(Name = "user-id")] long userId, [Required] IFormFile formFile)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._userAssetService.CreateAsync(userId, formFile)
        });

    [HttpGet("{user-id}")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromRoute(Name = "user-id")] long userId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._userAssetService.RetrieveAllAsync(userId, @params)
        });

    [HttpGet("{user-id}/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "user-id")] long userId, [FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._userAssetService.RetrieveByIdAsync(userId, id)

        });

    [HttpDelete("{user-id}/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "user-id")] long userId, [FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._userAssetService.RemoveAsync(userId, id)
        });


}
