namespace WAAI.Features.Wizard.Steps.Preferences;

public record PreferencesInfo
{
    public string Language { get; set; } = "en";
    public string Theme { get; set; } = "light";
    public bool Newsletter { get; set; }
}
