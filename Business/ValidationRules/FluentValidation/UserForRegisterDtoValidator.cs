using Business.Constants;
using Entities.Dtos.User;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().EmailAddress().WithMessage(Messages.EmailError);

            RuleFor(p => p.LastName).NotEmpty();

            RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8).WithMessage(Messages.PasswordLengthError)
            .Matches(@"[a-z]").WithMessage(Messages.PasswordContainsLowerCaseError)
            .Matches(@"[A-Z]").WithMessage(Messages.PasswordContainsUpperCaseError)
            .Matches(@"[0-9]").WithMessage(Messages.PasswordContainsNumberError)
            .Matches(@"[!@#$%^&*()\-_=+[\]{};:,./\\<>\?|]").WithMessage(Messages.PasswordContainsSymbolCharError);

        }

    }
}