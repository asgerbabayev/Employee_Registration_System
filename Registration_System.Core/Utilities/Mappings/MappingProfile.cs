namespace Registration_System.Core.Utilities.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeListDto>().ReverseMap();
        CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
        CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();

        CreateMap<Department, DepartmentListDto>().ReverseMap();
        CreateMap<Department, DepartmentCreateDto>().ReverseMap();
        CreateMap<Department, DepartmentUpdateDto>().ReverseMap();
    }
}
