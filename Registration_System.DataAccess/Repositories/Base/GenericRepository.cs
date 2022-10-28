namespace Registration_System.DataAccess.Repositories.Base;
public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
    where TEntity : BaseEntity, new()
    where TContext : DbContext
{
    private readonly AppDbContext _context;
    public GenericRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(TEntity entity)
    {
        EntityEntry newEntity = await _context.Set<TEntity>().AddAsync(entity);
        newEntity.State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(TEntity entity)
    {
        EntityEntry newEntity = _context.Set<TEntity>().Remove(entity);
        newEntity.State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes)
    {
        var query = GetQuery(includes);
        return exp is null
            ? await query.ToListAsync()
            : await query.Where(exp).ToListAsync();
    }

    public async Task<TEntity?> GetAsync(int id)
    => await _context.Set<TEntity>().FindAsync(id);
    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? predicate = null, bool tracking = true, params string[] includes)
    {
        IQueryable<TEntity> query = GetQuery(includes);
        if (!tracking)
            query = _context.Set<TEntity>().AsNoTracking();
        return predicate is null
        ? await query.FirstOrDefaultAsync()
        : await query.Where(predicate).FirstOrDefaultAsync();
    }

    public async Task Update(TEntity entity)
    {
        EntityEntry newEntity = _context.Set<TEntity>().Update(entity);
        newEntity.State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    private IQueryable<TEntity> GetQuery(params string[] includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();
        if (includes != null)
        {
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
        }
        return query;
    }
}
