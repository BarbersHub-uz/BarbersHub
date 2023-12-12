using MimeKit;
using MailKit.Net.Smtp;
using BarbersHub.Service.DTOs.Messages;
using Microsoft.Extensions.Configuration;
using BarbersHub.Service.Interfaces.IMessageServices;

namespace BarbersHub.Service.Services.MessageServices;

public class MessageService : IMessageService
{
    private readonly IConfiguration _configuration;

    public MessageService(IConfiguration configuration)
    {
        this._configuration = configuration.GetSection("Email");
    }

    public async Task SendEmail(MessageForCreationDto message)
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
        await smtp.AuthenticateAsync(_configuration["EmailAddress"], _configuration["password"]);

        await smtp.SendAsync(email);

        await smtp.DisconnectAsync(true);
    }
}
