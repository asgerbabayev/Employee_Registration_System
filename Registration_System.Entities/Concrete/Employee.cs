namespace Registration_System.Entities.Concrete;

public class Employee : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public decimal? Salary { get; set; }
    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; } = null!;
}
