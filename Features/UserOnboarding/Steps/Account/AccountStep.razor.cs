using Microsoft.AspNetCore.Components;

namespace WAAI.Features.UserOnboarding.Steps.Account;

public partial class AccountStep
{
    [Parameter] public AccountInfo Model { get; set; } = new();
}
