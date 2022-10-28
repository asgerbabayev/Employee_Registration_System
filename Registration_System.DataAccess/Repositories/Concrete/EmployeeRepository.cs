namespace Registration_System.DataAccess.Repositories.Concrete;
public class EmployeeRepository : GenericRepository<Employee, AppDbContext>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context) { }
}

