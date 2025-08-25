using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validations
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        #endregion

        #region Constructors
        public EditStudentValidator(IStudentService studentService)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _studentService = studentService;
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

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (key, CancellationToken) =>
                   !await _studentService.IsNameExist(key))
                .WithMessage("Student with this name already exists");
        }
        #endregion

    }
}
