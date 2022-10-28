namespace Registration_System.Business.ValidationRules.FluentValidation;
public class DepartmentValidator : AbstractValidator<Department>
{
    public DepartmentValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(1).MaximumLength(50);
        RuleFor(x => x.Location).NotEmpty().MinimumLength(1).MaximumLength(500);
    }
}
