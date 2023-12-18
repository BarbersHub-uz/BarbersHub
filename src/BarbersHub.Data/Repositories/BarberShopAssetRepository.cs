using BarbersHub.Data.DbContexts;
using BarbersHub.Data.IRepositories;
using BarbersHub.Domain.Entities.Assets;

namespace BarbersHub.Data.Repositories;

public class BarberShopAssetRepository : Repository<BarberShopAsset>, IBarberShopAssetRepository
{
    public BarberShopAssetRepository(AppDbContext dbContext) : base(dbContext)
    {   }
}
