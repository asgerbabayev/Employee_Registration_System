namespace Registration_System.DataAccess.DataContext;
public class AppDbContext : DbContext
{
    private readonly BaseEntitySaveChangesInterceptor _baseEntitySaveChangesInterceptor;
    public AppDbContext(DbContextOptions<AppDbContext> options, BaseEntitySaveChangesInterceptor baseEntitySaveChangesInterceptor) : base(options)
    {
        _baseEntitySaveChangesInterceptor = baseEntitySaveChangesInterceptor;
    }
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Department> Departments => Set<Department>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne(x => x.Department)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.DepartmentId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_baseEntitySaveChangesInterceptor);
    }
}
