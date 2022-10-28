namespace Registration_System.Business.Abstract;

public interface IEmployeeService
{
    Task<IResult> AddAsync(EmployeeCreateDto employeeCreateDto);
    Task<IDataResult<EmployeeListDto>> GetAsync(int id);
    Task<IDataResult<IEnumerable<EmployeeListDto>>> GetAllAsync();
    Task<IResult> Update(EmployeeUpdateDto employeeUpdateDto);
    Task<IResult> Delete(int id);
}

