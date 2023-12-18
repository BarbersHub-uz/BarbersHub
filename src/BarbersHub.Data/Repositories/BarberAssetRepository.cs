using BarbersHub.Data.DbContexts;
using BarbersHub.Data.IRepositories;
using BarbersHub.Domain.Entities.Assets;

namespace BarbersHub.Data.Repositories;

public class BarberAssetRepository : Repository<BarberAsset>, IBarberAssetRepository
{
    public BarberAssetRepository(AppDbContext dbContext) : base(dbContext)
    {   }
}
