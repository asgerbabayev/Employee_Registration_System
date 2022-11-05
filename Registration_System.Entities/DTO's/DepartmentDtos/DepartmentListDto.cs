using System.Text.Json.Serialization;

namespace Registration_System.Entities.DTO_s.DepartmentDtos;
public class DepartmentListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public ICollection<EmployeeListDto> Employees { get; set; }

    [JsonIgnore]
    public bool IsDeleted { get; set; }
    public DepartmentListDto()
    {
        Employees = new HashSet<EmployeeListDto>();
    }

}
