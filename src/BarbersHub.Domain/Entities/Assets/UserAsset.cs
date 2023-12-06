using BarbersHub.Domain.Entities.Users;

namespace BarbersHub.Domain.Entities.Assets;

public class UserAsset : Asset
{
    public long UserId { get; set; }
    public User User { get; set; }
}
