namespace WAAI.Features.Wizard.Steps.Account;

public record AccountInfo
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string ConfirmPassword { get; set; } = "";
}
