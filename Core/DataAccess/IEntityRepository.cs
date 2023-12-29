using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    // Generic Constraint
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> fiter = null);
        T Get(Expression<Func<T, bool>> fiter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
