using BarbersHub.Data.DbContexts;
using BarbersHub.Data.IRepositories;
using BarbersHub.Domain.Entities.Comments;

namespace BarbersHub.Data.Repositories;

public class CompletedRepository : Repository<Completed>, ICompletedRepository
{
    public CompletedRepository(AppDbContext dbContext) : base(dbContext)
    {   }
}
