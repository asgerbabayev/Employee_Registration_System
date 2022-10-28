namespace Registration_System.Entities.Concrete;
public class Department : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public virtual ICollection<Employee> Employees { get; set; }

    public Department()
    {
        Employees = new HashSet<Employee>();
    }
}
