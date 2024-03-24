using BarbersHub.Api.Models;
using Microsoft.AspNetCore.Mvc;
using BarbersHub.Service.DTOs.Logins;
using BarbersHub.Service.Interfaces.Accounts;
using BarbersHub.Service.Interfaces.AuthServices;

namespace BarbersHub.Api.Controllers.AuthController;

public class AuthController : BaseController
{
    private readonly IAccountService accountService;

    public AuthController(IAccountService accountService, IAuthService authService)
    {
        this.accountService = accountService;
    }

    [HttpPost]
    [Route("login")]
    public async ValueTask<IActionResult> login([FromBody] LoginDto loginDto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await accountService.LoginAsync(loginDto)
        });
}
