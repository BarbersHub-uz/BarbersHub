using BarbersHub.Data.DbContexts;
using BarbersHub.Data.IRepositories;
using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Data.Repositories;

public class BarberRepository : Repository<Barber>, IBarberRepository
{
    public BarberRepository(AppDbContext dbContext) : base(dbContext)
    {   }
}
