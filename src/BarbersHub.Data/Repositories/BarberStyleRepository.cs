using BarbersHub.Data.DbContexts;
using BarbersHub.Data.IRepositories;
using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Data.Repositories;

public class BarberStyleRepository : Repository<BarberStyle>, IBarberStyleRepository
{
    public BarberStyleRepository(AppDbContext dbContext) : base(dbContext)
    {   }
}
