using WAAI.Core.Models;

namespace WAAI.Features.UserOnboarding.Steps.Complete;

public class CompleteSummary : IStepModel
{
    public string FullName { get; init; } = "";
    public string Email { get; init; } = "";
    public string Username { get; init; } = "";
    public string Language { get; init; } = "";
    public string Theme { get; init; } = "";
}