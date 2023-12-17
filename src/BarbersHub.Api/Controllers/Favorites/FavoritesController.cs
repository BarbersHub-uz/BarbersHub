using BarbersHub.Api.Models;
using Microsoft.AspNetCore.Mvc;
using BarbersHub.Service.Configurations;
using BarbersHub.Service.Interfaces.Favorites;
using BarbersHub.Service.DTOs.Favorites.Favorites;

namespace BarbersHub.Api.Controllers.Favorites;

public class FavoritesController : BaseController
{
    private readonly IFavoriteService _favoriteService;
    public FavoritesController(IFavoriteService favoriteService)
        {
            this._favoriteService = favoriteService;
        }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] FavoriteForCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._favoriteService.AddAsync(dto)
        });
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._favoriteService.RetrieveAllAsync(@params)
        });
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._favoriteService.RetrieveByIdAsync(id)
        });
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._favoriteService.RemoveAsync(id)
        });
    [HttpPost("{id}")]
    public async Task<IActionResult> PostAsync([FromRoute(Name = "id")] long id, [FromBody] FavoriteForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._favoriteService.ModifyAsync(id, dto)
        });
}
