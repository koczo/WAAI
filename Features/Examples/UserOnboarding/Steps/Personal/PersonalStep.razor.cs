using Microsoft.AspNetCore.Components;

namespace WAAI.Features.Examples.UserOnboarding.Steps.Personal;

public partial class PersonalStep
{
    [Parameter] public PersonalInfo Model { get; set; } = new();
}