using BarbersHub.Data.DbContexts;
using BarbersHub.Data.IRepositories;
using BarbersHub.Domain.Entities.BarberShops;

namespace BarbersHub.Data.Repositories;

public class StyleRepository : Repository<Style>, IStyleRepository
{
    public StyleRepository(AppDbContext dbContext) : base(dbContext)
    {   }
}
