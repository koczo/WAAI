using System.ComponentModel.DataAnnotations;

namespace WAAI.Features.Wizard.Steps.Preferences;

public record PreferencesInfo
{
    [Required]
    public string Language { get; set; } = "en";

    [Required]
    public string Theme { get; set; } = "light";

    public bool Newsletter { get; set; }
}
