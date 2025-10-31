using FluentValidation;

namespace WAAI.Features.Wizard.Steps.Personal;

public class PersonalInfoValidator : AbstractValidator<PersonalInfo>
{
    public PersonalInfoValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MinimumLength(2);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Phone).Matches(@"^\+?\d[\d\s\-()]*$").When(x => !string.IsNullOrEmpty(x.Phone));
    }
}
