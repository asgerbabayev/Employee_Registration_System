namespace Registration_System.Business.ValidationRules.FluentValidation;
public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(1).MaximumLength(50);
        RuleFor(x => x.Surname).NotEmpty().MinimumLength(1).MaximumLength(80);
        RuleFor(x => x.BirthDate).NotEmpty();
        RuleFor(x => x.Gender).NotEmpty();
        RuleFor(x => x.Salary);
    }
}
