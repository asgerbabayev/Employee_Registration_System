using Registration_System.Entities.Concrete;
using System.Text.Json.Serialization;

namespace Registration_System.Entities.DTO_s.EmployeeDtos;
public class EmployeeListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public decimal? Salary { get; set; }
    public Department Department { get; set; } = null!;
    [JsonIgnore]
    public bool IsDeleted { get; set; }
}
