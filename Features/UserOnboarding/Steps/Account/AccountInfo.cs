using WAAI.Core.Models;

namespace WAAI.Features.UserOnboarding.Steps.Account;

public class AccountInfo : IStepModel
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string ConfirmPassword { get; set; } = "";
}