using WAAI.Core.Models;

namespace WAAI.Features.UserOnboarding.Steps.Preferences;

public class PreferencesInfo : IStepModel
{
    public string Language { get; set; } = "en";
    public string Theme { get; set; } = "light";
    public bool Newsletter { get; set; }
}
