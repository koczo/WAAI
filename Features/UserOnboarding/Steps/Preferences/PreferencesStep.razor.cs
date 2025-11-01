using Microsoft.AspNetCore.Components;

namespace WAAI.Features.UserOnboarding.Steps.Preferences;

public partial class PreferencesStep
{
    [Parameter] public PreferencesInfo Model { get; set; } = new();

    private void SetThemeLight() => Model.Theme = "light";
    private void SetThemeDark() => Model.Theme = "dark";
    private void SetThemeAuto() => Model.Theme = "auto";

    private string GetThemeButtonClass(string themeValue) =>
        Model.Theme == themeValue
            ? "border-2 border-indigo-600 bg-indigo-50"
            : "border-2 border-gray-300";
}
