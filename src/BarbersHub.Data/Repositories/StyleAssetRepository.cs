using BarbersHub.Data.DbContexts;
using BarbersHub.Data.IRepositories;
using BarbersHub.Domain.Entities.Assets;

namespace BarbersHub.Data.Repositories;

public class StyleAssetRepository : Repository<StyleAsset>, IStyleAssetRepository
{
	public StyleAssetRepository(AppDbContext dbContext) : base(dbContext)
	{	}
}
