using FluentValidation;
using KUSYS.Core.Contracts.DTOs;

namespace KUSYS.Business.Validator
{
    public class CourseValidator: AbstractValidator<CourseDTO>
    {
        public CourseValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id field can not be empty!");

            RuleFor(x => x.CourseName)
                .NotEmpty().WithMessage("Course Name field can not be empty!")
                .MaximumLength(5).WithMessage("Course Name length must be between 1 and 255!")
                .MaximumLength(255).WithMessage("Course Name length must be between 1 and 255!");
        }
    }
}
