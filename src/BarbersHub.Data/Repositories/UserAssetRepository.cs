using BarbersHub.Data.DbContexts;
using BarbersHub.Data.IRepositories;
using BarbersHub.Domain.Entities.Assets;

namespace BarbersHub.Data.Repositories;

public class UserAssetRepository : Repository<UserAsset>, IUserAssetRepository
{
    public UserAssetRepository(AppDbContext dbContext) : base(dbContext)
    {   }
}
