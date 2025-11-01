using Microsoft.AspNetCore.Components;

namespace WAAI.Features.UserOnboarding.Steps.Complete;

public partial class CompleteStep
{
    [Parameter] public CompleteSummary Summary { get; set; } = new();
}