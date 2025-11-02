using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using WAAI.Core.Models;
using WAAI.Features.Examples.UserOnboarding.Steps.Account;
using WAAI.Features.Examples.UserOnboarding.Steps.Complete;
using WAAI.Features.Examples.UserOnboarding.Steps.Personal;
using WAAI.Features.Examples.UserOnboarding.Steps.Preferences;

namespace WAAI.Features.Examples.UserOnboarding;

public partial class UserOnboarding
{
    [Inject] private ILocalStorageService LocalStorage { get; set; } = default!;
    [Inject] private NavigationManager Navigation { get; set; } = default!;

    private readonly AccountInfo _accountInfo = new();
    private readonly Dictionary<OnboardingStep, IStepModel> _models;
    private readonly PersonalInfo _personalInfo = new();
    private readonly PreferencesInfo _preferencesInfo = new();
    private CompleteSummary _completeSummary = new();
    private OnboardingStep _currentStep = OnboardingStep.Personal;

    public UserOnboarding()
    {
        _models = new Dictionary<OnboardingStep, IStepModel>
        {
            [OnboardingStep.Personal] = _personalInfo,
            [OnboardingStep.Account] = _accountInfo,
            [OnboardingStep.Preferences] = _preferencesInfo,
            [OnboardingStep.Complete] = _completeSummary
        };
    }

    private Task OnStepChanged(OnboardingStep newStep)
    {
        _currentStep = newStep;
        if (_currentStep == OnboardingStep.Complete)
        {
            CreateSummary();
        }
        return Task.CompletedTask;
    }

    private async Task Finish()
    {
        var user = new User
        {
            FullName = _personalInfo.FullName,
            Email = _personalInfo.Email,
            Phone = _personalInfo.Phone,
            Username = _accountInfo.Username,
            Language = _preferencesInfo.Language,
            Theme = _preferencesInfo.Theme,
            Newsletter = _preferencesInfo.Newsletter,
            CreatedAt = DateTime.UtcNow
        };

        var users = await LocalStorage.GetItemAsync<List<User>>("users") ?? [];
        users.Add(user);
        await LocalStorage.SetItemAsync("users", users);

        Navigation.NavigateTo("/users");
    }

    private void CreateSummary()
    {
        _completeSummary.FullName = _personalInfo.FullName;
        _completeSummary.Email = _personalInfo.Email;
        _completeSummary.Username = _accountInfo.Username;
        _completeSummary.Language = _preferencesInfo.Language;
        _completeSummary.Theme = _preferencesInfo.Theme;
    }
}