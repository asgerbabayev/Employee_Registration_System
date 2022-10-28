namespace Registration_System.Core;
public static class ServicesConfiguration
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
