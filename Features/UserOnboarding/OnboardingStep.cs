using Ardalis.SmartEnum;

namespace WAAI.Features.UserOnboarding;

public class OnboardingStep : SmartEnum<OnboardingStep>
{
    public static readonly OnboardingStep Personal = new(nameof(Personal), (int)Order.Personal);
    public static readonly OnboardingStep Account = new(nameof(Account), (int)Order.Account);
    public static readonly OnboardingStep Preferences = new(nameof(Preferences), (int)Order.Preferences);
    public static readonly OnboardingStep Complete = new(nameof(Complete), (int)Order.Complete);

    private OnboardingStep(string name, int value) : base(name, value)
    {
    }

    private enum Order
    {
        Personal = 1,
        Account = 2,
        Preferences = 3,
        Complete = 4
    }
}