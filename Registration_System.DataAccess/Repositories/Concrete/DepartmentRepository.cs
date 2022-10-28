using Microsoft.EntityFrameworkCore;
using Registration_System.DataAccess.DataContext;

namespace Registration_System.DataAccess.Repositories.Concrete;
public class DepartmentRepository : GenericRepository<Department, AppDbContext>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context) : base(context) { }
}
