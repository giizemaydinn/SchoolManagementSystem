using Business.Constants;
using Entities.Dtos.Student;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AddStudentDtoValidator : AbstractValidator<AddStudentDto>
    {
        public AddStudentDtoValidator()
        {

            RuleFor(p => p.ParentId).NotEmpty();

            RuleFor(p => p.FirstName)
                .NotEmpty()
                .Must(StartWithInvalidChar).WithMessage(Messages.StartWithInvalidChar);

        }

        private bool StartWithInvalidChar(string arg)
        {

            return !arg.StartsWith("Ğ") && !arg.StartsWith("ğ");
        }
    }
}