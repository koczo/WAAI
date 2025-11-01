using Microsoft.AspNetCore.Components;
using WAAI.Core.Models;
using WAAI.Features.UserOnboarding.Steps.Account;
using WAAI.Features.UserOnboarding.Steps.Complete;
using WAAI.Features.UserOnboarding.Steps.Personal;
using WAAI.Features.UserOnboarding.Steps.Preferences;

namespace WAAI.Features.UserOnboarding;

public partial class UserOnboarding
{
    private OnboardingStep _currentStep = OnboardingStep.Personal;
    private readonly PersonalInfo _personalInfo = new();
    private readonly AccountInfo _accountInfo = new();
    private readonly PreferencesInfo _preferencesInfo = new();
    private readonly Dictionary<OnboardingStep, IStepModel> _models;

    public UserOnboarding()
    {
        _models = new()
        {
            [OnboardingStep.Personal] = _personalInfo,
            [OnboardingStep.Account] = _accountInfo,
            [OnboardingStep.Preferences] = _preferencesInfo
        };
    }

    private Task OnStepChanged(OnboardingStep newStep)
    {
        _currentStep = newStep;
        return Task.CompletedTask;
    }

    private void Finish() => _currentStep = OnboardingStep.Personal;

    private CompleteSummary CreateSummary() => new()
    {
        FullName = _personalInfo.FullName,
        Email = _personalInfo.Email,
        Username = _accountInfo.Username,
        Language = _preferencesInfo.Language,
        Theme = _preferencesInfo.Theme
    };
}
