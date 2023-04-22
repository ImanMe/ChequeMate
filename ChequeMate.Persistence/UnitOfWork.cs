using ChequeMate.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChequeMate.Persistence;

public class UnitOfWork<TContext> : IUnitOfWork<TContext>
    where TContext : DbContext
{
    private readonly TContext _dbContext;

    public UnitOfWork(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void BeginTransaction()
    {
        _dbContext.Database.BeginTransaction();
    }

    public async Task<bool> CommitAsync()
    {
        await _dbContext.Database.CommitTransactionAsync();
        return true;
    }

    public async Task RollbackAsync()
    {
        await _dbContext.Database.RollbackTransactionAsync();
    }
}