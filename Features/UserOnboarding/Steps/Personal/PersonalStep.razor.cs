using Microsoft.AspNetCore.Components;

namespace WAAI.Features.UserOnboarding.Steps.Personal;

public partial class PersonalStep
{
    [Parameter] public PersonalInfo Model { get; set; } = new();
}