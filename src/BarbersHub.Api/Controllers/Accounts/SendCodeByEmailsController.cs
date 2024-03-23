using BarbersHub.Api.Controllers;
using BarbersHub.Api.Models;
using BarbersHub.Service.Interfaces.Accounts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Teydes.Api.Controllers.Accounts;

public class SendCodeByEmailsController : BaseController
{
    private readonly IEmailService emailService;

    public SendCodeByEmailsController(IEmailService emailService)
    {
        this.emailService = emailService;
    }

    [HttpPost("send-code")]

    public async Task<IActionResult> SendCodeByEmailAsync([EmailAddress, Required] string email)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.emailService.SendCodeByEmailAsync(email)
        });


    [HttpPost("verify-code")]

    public IActionResult VerifyCode([EmailAddress, Required] string email, [Required] string code)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = this.emailService.VerifyCode(email, code)
        });
}
