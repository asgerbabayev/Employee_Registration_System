namespace Registration_System.Entities.DTO_s.EmployeeDtos;
public class EmployeeUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public decimal? Salary { get; set; }
}
