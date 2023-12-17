using BarbersHub.Service.DTOs.Messages;

namespace BarbersHub.Service.Interfaces.IMessageServices;

public interface IMessageService
{
    public Task SendEmail(MessageForCreationDto message);
}
