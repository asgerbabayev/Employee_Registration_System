namespace Registration_System.DataAccess.Repositories.Base;
public interface IGenericRepository<T> 
    where T : BaseEntity, new()
{
    Task<T?> GetAsync(int id);
    Task<T?> GetAsync(Expression<Func<T, bool>>? predicate = null, bool tracking = true, params string[] includes);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> exp = null, params string[] includes);
    Task AddAsync(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}
