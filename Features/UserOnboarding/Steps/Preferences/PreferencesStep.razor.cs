using Microsoft.AspNetCore.Components;

namespace WAAI.Features.UserOnboarding.Steps.Preferences;

public partial class PreferencesStep
{
    [Parameter] public PreferencesInfo Model { get; set; } = new();

    private void SetThemeLight()
    {
        Model.Theme = "light";
    }

    private void SetThemeDark()
    {
        Model.Theme = "dark";
    }

    private void SetThemeAuto()
    {
        Model.Theme = "auto";
    }
}