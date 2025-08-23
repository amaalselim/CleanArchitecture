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
                .NotEmpty().WithMessage("{PropertyName} Must Not Be Empty")
                .NotNull().WithMessage("{PropertyValue} Must Not Be Null")
                .MaximumLength(00).WithMessage("{PropertyName} cannot exceed 10 characters");


        }
        #endregion

    }
}
