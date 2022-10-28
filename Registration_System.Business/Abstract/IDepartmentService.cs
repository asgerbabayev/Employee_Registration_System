namespace Registration_System.Business.Abstract;
public interface IDepartmentService
{
    Task<IResult> AddAsync(DepartmentCreateDto departmentCreateDto);
    Task<IDataResult<DepartmentListDto>> GetAsync(int id);
    Task<IDataResult<IEnumerable<DepartmentListDto>>> GetAllAsync();
    Task<IResult> Update(DepartmentUpdateDto departmentUpdateDto);
    Task<IResult> Delete(int id);
}
