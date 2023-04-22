using System.Linq.Expressions;

namespace ChequeMate.Domain.Contracts;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    Task<T> GetById(object id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}