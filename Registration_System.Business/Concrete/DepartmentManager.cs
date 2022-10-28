namespace Registration_System.Business.Concrete;
public class DepartmentManager : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;
    public DepartmentManager(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }
    public async Task<IResult> AddAsync(DepartmentCreateDto departmentCreateDto)
    {
        await _departmentRepository.AddAsync(_mapper.Map<Department>(departmentCreateDto));
        return new Result(true, Messages.DepartmentCreated);
    }

    public async Task<IResult> Delete(int id)
    {
        var exist = await _departmentRepository.GetAsync(x => x.Id == id);
        if (exist == null) return new Result(false, Messages.DepartmentNotFound);
        exist.IsDeleted = true;
        await _departmentRepository.Update(exist);
        return new Result(true, Messages.DepartmentDeleted);
    }

    public async Task<IDataResult<IEnumerable<DepartmentListDto>>> GetAllAsync()
    {
        return new SuccessDataResult<IEnumerable<DepartmentListDto>>
                (_mapper.Map<IEnumerable<DepartmentListDto>>
                (await _departmentRepository.GetAllAsync(x=>x.IsDeleted == false, includes: nameof(DepartmentListDto.Employees))));
    }

    public async Task<IDataResult<DepartmentListDto>> GetAsync(int id)
    {
        var exist = await _departmentRepository.GetAsync(x => x.Id == id, includes: nameof(DepartmentListDto.Employees));
        if (exist is null) return new ErrorDataResult<DepartmentListDto>(Messages.DepartmentNotFound);
        return new SuccessDataResult<DepartmentListDto>(_mapper.Map<DepartmentListDto>(exist));
    }

    public async Task<IResult> Update(DepartmentUpdateDto departmentUpdateDto)
    {
        await _departmentRepository.Update(_mapper.Map<Department>(departmentUpdateDto));
        return new Result(true, Messages.DepartmentUpdated);
    }
}
