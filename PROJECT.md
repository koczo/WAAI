# WAAI - Wizard Application Architecture & Info

## Architektura

### Struktura folderów
```
WAAI/
├── Features/
│   └── UserOnboarding/
│       ├── UserOnboarding.razor         # Główna strona onboardingu
│       ├── OnboardingStep.cs            # SmartEnum kroków
│       ├── OnboardingStepper.razor      # Stepper UI
│       └── Steps/
│           ├── Personal/
│           │   ├── PersonalStep.razor
│           │   ├── PersonalInfo.cs
│           │   └── PersonalInfoValidator.cs
│           ├── Account/
│           │   ├── AccountStep.razor
│           │   ├── AccountInfo.cs
│           │   └── AccountInfoValidator.cs
│           ├── Preferences/
│           │   ├── PreferencesStep.razor
│           │   └── PreferencesInfo.cs
│           └── Complete/
│               └── CompleteStep.razor
└── Core/
    └── Components/
        ├── Button.razor
        ├── Card.razor
        ├── PageHeader.razor
        ├── StepWizard.razor
        ├── WizardStepBase.cs
        └── ValidationMessageWithTooltip.razor
```

## Komponenty Core

### StepWizard.razor
Generyczny komponent wizarda z:
- `TStep` - SmartEnum definiujący kroki
- `EditForm` + `FluentValidator` - walidacja
- Automatyczna nawigacja Next/Previous
- `OnStepChanged` callback
- `OnCompleted` callback

**Użycie:**
```razor
<StepWizard TStep="OnboardingStep" 
            CurrentStep="@currentStep"
            OnStepChanged="HandleStepChanged"
            OnCompleted="HandleCompleted">
    @if (currentStep == OnboardingStep.Personal)
    {
        <PersonalStep @bind-Model="personalInfo" />
    }
</StepWizard>
```

### WizardStepBase.cs
Klasa bazowa dla kroków wizarda:
- `[CascadingParameter] EditContext EditContext`
- `[Parameter] TModel Model { get; set; }`
- `[Parameter] EventCallback<TModel> ModelChanged { get; set; }`

### ValidationMessageWithTooltip.razor
Wyświetla pierwszy błąd walidacji + tooltip z pozostałymi:
- Pokazuje pierwszy błąd inline
- "+N" z tooltipem dla dodatkowych błędów
- Integracja z `EditContext.OnValidationStateChanged`

### Button.razor
Warianty: Primary, Secondary, Success
Właściwości: Disabled, Visible, OnClick

### Card.razor / PageHeader.razor
Komponenty layoutu z Tailwind CSS

## Walidacja

### FluentValidation
- Rejestracja w `Program.cs`: `builder.Services.AddScoped<IValidator<PersonalInfo>, PersonalInfoValidator>()`
- Blazilla package (1.1.0) dla integracji z EditForm
- Walidacja reaktywna - blokuje submit, nie disabled button

### Przykład validatora:
```csharp
public class PersonalInfoValidator : AbstractValidator<PersonalInfo>
{
    public PersonalInfoValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Imię i nazwisko jest wymagane")
            .MinimumLength(3).WithMessage("Minimum 3 znaki");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email jest wymagany")
            .EmailAddress().WithMessage("Nieprawidłowy format email");
    }
}
```

## Wzorce i decyzje

### Feature-based architecture
Każda funkcjonalność w osobnym folderze z komponentami, modelami i walidatorami

### Binding w krokach wizarda
```razor
<PersonalStep @bind-Model="personalInfo" />
```

### Nawigacja wizarda
- Previous: ukryty na pierwszym kroku
- Next: zawsze widoczny, walidacja blokuje submit
- Przyciski zawsze wyrównane do prawej

### UX
- Język: Polski
- Tailwind CSS dla stylowania
- Minimalistyczny design
- Walidacja nie blokuje UI, tylko submit

## Packages
- FluentValidation (12.0.0)
- Blazilla (1.1.0) - FluentValidation dla Blazor
