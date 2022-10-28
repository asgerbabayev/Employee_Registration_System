using FluentValidation.AspNetCore;
using System.Reflection;

namespace Registration_System.Business;
public static class ServicesConfiguration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation(configuration => configuration.DisableDataAnnotationsValidation = false)
                .AddFluentValidationClientsideAdapters();
        services.AddScoped<IEmployeeService, EmployeeManager>();
        services.AddScoped<IDepartmentService, DepartmentManager>();
        return services;
    }
}
