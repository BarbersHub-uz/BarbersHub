using BarbersHub.Data.DbContexts;
using BarbersHub.Data.IRepositories;
using BarbersHub.Domain.Entities.Users;

namespace BarbersHub.Data.Repositories;

public class UserRepository : Repository<User> , IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {   }
}
