using Microsoft.AspNetCore.Components;

namespace WAAI.Features.Examples.UserOnboarding.Steps.Complete;

public partial class CompleteStep
{
    [Parameter] public CompleteSummary Summary { get; set; } = new();
}