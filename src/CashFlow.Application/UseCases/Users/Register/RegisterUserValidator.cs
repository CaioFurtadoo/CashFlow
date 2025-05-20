using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ResourceErrorMessage.NAME_EMPTY);
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(ResourceErrorMessage.EMAIL_EMPTY)
                .EmailAddress()
                .WithMessage(ResourceErrorMessage.EMAIL_INVALID);

            RuleFor(x => x.Password).SetValidator(new PasswordValidator<RequestRegisterUserJson>());
        }

    }
}
