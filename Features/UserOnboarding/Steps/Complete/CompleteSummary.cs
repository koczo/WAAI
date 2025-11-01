using WAAI.Core.Models;

namespace WAAI.Features.UserOnboarding.Steps.Complete;

public class CompleteSummary : IStepModel
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } =string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Theme { get; set; } = string.Empty;
}