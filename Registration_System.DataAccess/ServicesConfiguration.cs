namespace Registration_System.DataAccess;
public static class ServicesConfiguration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<BaseEntitySaveChangesInterceptor>();

        services.AddDbContext<AppDbContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("db"),
                    builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        return services;
    }
}
