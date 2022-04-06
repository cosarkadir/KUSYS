using FluentValidation;
using KUSYS.Core.Contracts.DTOs;

namespace KUSYS.Business.Validator
{
    public class StudentValidator : AbstractValidator<StudentDTO>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id field can not be empty!");

            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("Course Id field can not be empty!");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name field can not be empty!")
                .MaximumLength(5).WithMessage("First Name length must be between 2 and 255!")
                .MaximumLength(255).WithMessage("First Name length must be between 2 and 255!");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name field can not be empty!")
                .MaximumLength(5).WithMessage("Last Name length must be between 2 and 255!")
                .MaximumLength(255).WithMessage("Last Name length must be between 2 and 255!");
        }
    }
}
