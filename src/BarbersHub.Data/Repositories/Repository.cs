using BarbersHub.Domain.Commons;
using BarbersHub.Data.DbContexts;
using BarbersHub.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BarbersHub.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly AppDbContext _dbContext;

    public Repository(DbSet<TEntity> dbSet, AppDbContext dbContext)
    {
        this._dbSet = dbSet;
        this._dbContext = dbContext;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await this._dbSet.FirstOrDefaultAsync(e => e.Id == id);
        entity.IsDeleted = true;
        this._dbSet.Remove(entity);

        return await this._dbContext.SaveChangesAsync() > 0;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var model = await this._dbSet.AddAsync(entity);
        await this._dbContext.SaveChangesAsync();

        return entity;
    }

    public IQueryable<TEntity> SelectAll()
        => this._dbSet;

    public async Task<TEntity> SelectByIdAsync(long id)
        => await this._dbSet.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var model = this._dbSet.Update(entity);
        await this._dbContext.SaveChangesAsync();

        return model.Entity;
    }
}
