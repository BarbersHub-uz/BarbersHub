using BarbersHub.Data.DbContexts;
using BarbersHub.Data.IRepositories;
using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Data.Repositories;

public class BarberShopRepository : Repository<BarberShop>, IBarberShopRepository
{
    public BarberShopRepository(AppDbContext dbContext) : base(dbContext)
    {   }
}
