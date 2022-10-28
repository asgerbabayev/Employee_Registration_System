namespace Registration_System.Business.Concrete;
public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    public async Task<IResult> AddAsync(EmployeeCreateDto employeeCreateDto)
    {
        await _employeeRepository.AddAsync(_mapper.Map<Employee>(employeeCreateDto));
        return new Result(true, Messages.EmployeeCreated);
    }

    public async Task<IResult> Delete(int id)
    {
        var exist = await _employeeRepository.GetAsync(x => x.Id == id);
        if (exist == null) return new Result(false, Messages.EmployeeNotFound);
        exist.IsDeleted = true;
        await _employeeRepository.Update(exist);
        return new Result(true, Messages.EmployeeDeleted);
    }

    public async Task<IDataResult<IEnumerable<EmployeeListDto>>> GetAllAsync()
    {
        return new SuccessDataResult<IEnumerable<EmployeeListDto>>
            (_mapper.Map<IEnumerable<EmployeeListDto>>
            (await _employeeRepository.GetAllAsync(x => x.IsDeleted == false, includes: nameof(EmployeeListDto.Department))));
    }

    public async Task<IDataResult<EmployeeListDto>> GetAsync(int id)
    {
        var exist = await _employeeRepository.GetAsync(x=>x.Id == id,includes: nameof(EmployeeListDto.Department));
        if (exist is null) return new ErrorDataResult<EmployeeListDto>(Messages.EmployeeNotFound);
        return new SuccessDataResult<EmployeeListDto>(_mapper.Map<EmployeeListDto>(exist));
    }
    public async Task<IResult> Update(EmployeeUpdateDto employeeUpdateDto)
    {
        await _employeeRepository.Update(_mapper.Map<Employee>(employeeUpdateDto));
        return new Result(true, Messages.EmployeeUpdated);
    }
}
