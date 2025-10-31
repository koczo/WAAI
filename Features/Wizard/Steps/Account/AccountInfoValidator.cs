using FluentValidation;

namespace WAAI.Features.Wizard.Steps.Account;

public class AccountInfoValidator : AbstractValidator<AccountInfo>
{
    public AccountInfoValidator()
    {
        RuleFor(x => x.Username).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password);
    }
}
