# Learnings - WAAI Project

## Blazor Patterns

### 1. Generic Components z Enum Constraints

```csharp
@typeparam TStep where TStep : struct, Enum
```

Pozwala tworzyć reużywalne komponenty dla różnych enumów (np. StepWizard dla dowolnego wizarda)

### 2. CascadingParameter dla EditContext

```csharp
[CascadingParameter] 
public EditContext EditContext { get; set; }
```

EditForm automatycznie przekazuje EditContext w dół drzewa komponentów - nie trzeba ręcznie przekazywać przez parametry

### 3. Two-way Binding w komponentach

```csharp
[Parameter] public TModel Model { get; set; }
[Parameter] public EventCallback<TModel> ModelChanged { get; set; }
```

Konwencja nazewnicza: `Model` + `ModelChanged` = `@bind-Model`

### 4. RenderFragment dla dynamicznej zawartości

```razor
[Parameter] public RenderFragment ChildContent { get; set; }

<div>
    @ChildContent
</div>
```

Pozwala komponentowi renderować dowolną zawartość przekazaną między tagami

### 5. OnValidationStateChanged Event

```csharp
EditContext.OnValidationStateChanged += (sender, args) => StateHasChanged();
```

Subskrypcja na zmiany walidacji pozwala reagować na błędy w czasie rzeczywistym

## FluentValidation w Blazor

### 1. Blazilla vs Blazored.FluentValidation

- **Blazilla** (1.1.0) - nowszy, lepiej utrzymywany, prostsza integracja
- **Blazored.FluentValidation** - starszy, więcej boilerplate

### 2. Rejestracja w DI

```csharp
builder.Services.AddScoped<IValidator<TModel>, TValidator>();
```

Każdy validator jako osobny serwis

### 3. Integracja z EditForm

```razor
<EditForm Model="@model" OnValidSubmit="HandleSubmit">
    <FluentValidator TValidator="PersonalInfoValidator" />
    <ValidationMessage For="@(() => model.Property)" />
</EditForm>
```

### 4. Custom Validation Messages

```csharp
RuleFor(x => x.Password)
    .Equal(x => x.ConfirmPassword)
    .WithMessage("Hasła muszą być identyczne");
```

## Tailwind CSS Tricks

### 1. Group Hover dla Tooltips

```html
<div class="group relative">
    <span>+2</span>
    <div class="invisible group-hover:visible">Tooltip</div>
</div>
```

Parent z `group`, child z `group-hover:*` - hover na parent wpływa na child

### 2. Conditional Classes

```razor
class="@(IsActive ? "bg-blue-500" : "bg-gray-500")"
```

### 3. Responsive Spacing

```html
<div class="space-y-4">  <!-- vertical spacing między children -->
```

## Architecture Insights

### 1. Feature-based > Layer-based

```
✅ Features/Wizard/Steps/Personal/
❌ Pages/Wizard/ + Models/Personal/
```

Wszystko związane z feature w jednym miejscu

### 2. Separation of Concerns

- **Component** (.razor) - UI + interakcje
- **Model** (.cs) - dane
- **Validator** (.cs) - reguły walidacji

### 3. Reusable Components w Core/

Komponenty używane w wielu miejscach (Button, Card) oddzielone od feature-specific

### 4. Base Classes dla wspólnej logiki

`WizardStepBase<TModel>` - wspólna logika dla wszystkich kroków wizarda

## UX Patterns

### 1. Validation UX

- ❌ Disabled button gdy błędy - frustrujące, użytkownik nie wie dlaczego
- ✅ Active button + validation messages - jasny feedback

### 2. Progressive Disclosure

- Pokazuj tylko aktualny krok
- Ukrywaj Previous na pierwszym kroku
- Zawsze pokazuj Next (walidacja blokuje submit)

### 3. Multi-error Display

- Pierwszy błąd inline
- Dodatkowe błędy w tooltip
- "+N" indicator dla czytelności

## C# Techniques

### 1. Enum Extensions

```csharp
public static class EnumExtensions
{
    public static TEnum Next<TEnum>(this TEnum value) where TEnum : struct, Enum
    {
        var values = Enum.GetValues<TEnum>();
        var index = Array.IndexOf(values, value);
        return index < values.Length - 1 ? values[index + 1] : value;
    }
}
```

### 2. Generic Constraints

```csharp
where TStep : struct, Enum  // tylko enum
where TModel : class, new() // tylko klasy z konstruktorem bezparametrowym
```

### 3. EventCallback vs Action

- `EventCallback` - Blazor-aware, automatyczny StateHasChanged
- `Action` - zwykły delegate, wymaga ręcznego StateHasChanged

## Debugging Tips

### 1. EditContext.Validate()

Ręczne wywołanie walidacji przed submit

### 2. EditContext.GetValidationMessages()

Pobieranie wszystkich błędów dla pola

### 3. @key directive

```razor
@foreach (var item in items)
{
    <Component @key="item.Id" Data="@item" />
}
```

Pomaga Blazor śledzić komponenty przy re-renderze

## Performance

### 1. StateHasChanged() ostrożnie

Wywołuj tylko gdy naprawdę potrzeba re-renderu

### 2. EventCallback automatycznie wywołuje StateHasChanged

Nie trzeba ręcznie w większości przypadków

### 3. @key dla list

Optymalizuje diffing algorytm Blazora

## Minimal Code Philosophy

### 1. Unikaj boilerplate

- Używaj konwencji (np. @bind-*)
- Wykorzystuj cascading parameters
- Generic components zamiast duplikacji

### 2. Jeden plik = jedna odpowiedzialność

- Component = UI
- Model = data
- Validator = rules

### 3. Tailwind > custom CSS

Mniej plików, szybszy development, konsystentny design
