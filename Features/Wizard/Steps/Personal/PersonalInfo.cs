namespace WAAI.Features.Wizard.Steps.Personal;

public record PersonalInfo
{
    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
}
