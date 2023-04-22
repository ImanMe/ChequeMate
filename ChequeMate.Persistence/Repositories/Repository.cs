using ChequeMate.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChequeMate.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    public readonly DbSet<T> DbSet;

    public Repository(DbSet<T> dbSet)
    {
        DbSet = dbSet;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
        return await DbSet.Where(predicate).ToListAsync();
    }

    public async Task<T> GetById(object id)
    {
        return await DbSet.FindAsync(id);
    }

    public void Add(T entity)
    {
        DbSet.Add(entity);
    }

    public void Update(T entity)
    {
        DbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }
}