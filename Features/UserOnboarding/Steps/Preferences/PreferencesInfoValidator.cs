using FluentValidation;

namespace WAAI.Features.UserOnboarding.Steps.Preferences;

public class PreferencesInfoValidator : AbstractValidator<PreferencesInfo>
{
    public PreferencesInfoValidator()
    {
        RuleFor(x => x.Language).NotEmpty();
        RuleFor(x => x.Theme).NotEmpty();
    }
}