using WAAI.Core.Models;

namespace WAAI.Features.Examples.UserOnboarding.Steps.Personal;

public class PersonalInfo : IStepModel
{
    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
}