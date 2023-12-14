using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;
using BarbersHub.Service.Interfaces.Accounts;
using BarbersHub.Service.Services.Accounts.Models;

namespace BarbersHub.Service.Services.Accounts;

public class EmailService : IEmailService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IConfiguration _configuration;
    public EmailService(IConfiguration configuration, IMemoryCache memoryCache)
    {
        this._memoryCache = memoryCache;
        this._configuration = configuration.GetSection("Email");
    }
    public async Task<bool> SendCodeByEmailAsync(string email)
    {
        var randomNumber = new Random().Next(100000, 999999);

        var message = new Message()
        {
            Subject = "Do not give this code to Others",
            To = email,
            Body = $"{randomNumber}"
        };

        _memoryCache.Set(email, randomNumber.ToString(), TimeSpan.FromMinutes(2));
        await this.SendMessageAsync(message);

        return true;
    }

    public async Task SendMessageAsync(Message message)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_configuration["EmailAddress"]));
        email.To.Add(MailboxAddress.Parse(message.To));

        email.Subject = message.Subject;
        email.Body = new TextPart("html")
        {
            Text = message.Body
        };

        var smtp = new SmtpClient();

        await smtp.ConnectAsync(_configuration["Host"], 587, MailKit.Security.SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_configuration["EmailAddress"], _configuration["Password"]);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }

    public bool VerifyCode(string email, string code)
    {
        var cashedValue = _memoryCache.Get<string>(email);

        if (cashedValue?.ToString() == code)
        {
            return true;
        }

        return false;
    }
}
