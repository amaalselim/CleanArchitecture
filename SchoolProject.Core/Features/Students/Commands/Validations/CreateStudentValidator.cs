using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;

namespace SchoolProject.Core.Features.Students.Commands.Validations
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        #region Fields
        #endregion

        #region Constructors
        public CreateStudentValidator()
        {
            ApplyValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name Must Not Be Empty")
                .NotNull().WithMessage("Name Must Not Be Null")
                .MaximumLength(00).WithMessage("Name cannot exceed 10 characters");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{Property Name} Must Not Be Empty")
                .NotNull().WithMessage("{Property Value} Must Not Be Null")
                .MaximumLength(00).WithMessage("{Property Name} cannot exceed 10 characters");


        }
        #endregion

    }
}
