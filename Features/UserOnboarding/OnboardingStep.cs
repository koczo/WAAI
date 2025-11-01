using Ardalis.SmartEnum;

namespace WAAI.Features.UserOnboarding;

public class OnboardingStep : SmartEnum<OnboardingStep>
{
    public static readonly OnboardingStep Personal = new(nameof(Personal), 1);
    public static readonly OnboardingStep Account = new(nameof(Account), 2);
    public static readonly OnboardingStep Preferences = new(nameof(Preferences), 3);
    public static readonly OnboardingStep Complete = new(nameof(Complete), 4);

    private OnboardingStep(string name, int value) : base(name, value) { }
}
