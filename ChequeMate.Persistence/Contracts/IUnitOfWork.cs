using Microsoft.EntityFrameworkCore;

namespace ChequeMate.Persistence.Contracts;

public interface IUnitOfWork<T> where T : DbContext
{
    Task<int> SaveChangesAsync();
    void BeginTransaction();
    Task<bool> CommitAsync();
    Task RollbackAsync();
}