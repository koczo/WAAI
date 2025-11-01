using Ardalis.SmartEnum;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using WAAI.Core.Models;

namespace WAAI.Core.Components;

public partial class StepWizard<TStep> where TStep : SmartEnum<TStep>
{
    [Parameter] public TStep CurrentStep { get; set; } = default!;
    [Parameter] public EventCallback<TStep> CurrentStepChanged { get; set; }
    [Parameter] public RenderFragment? StepContent { get; set; }
    [Parameter] public Dictionary<TStep, IStepModel> Models { get; set; } = null!;
    [Parameter] public EventCallback OnComplete { get; set; }
    [Parameter] public string CompleteButtonText { get; set; } = "Finish ✓";
    [Parameter] public bool ShowProgressStepper { get; set; } = true;

    private EditContext _editContext = null!;
    private List<TStep> _steps = null!;

    protected override void OnInitialized()
    {
        _steps = SmartEnum<TStep>.List.OrderBy(x => x).ToList();
        _editContext = new EditContext(GetModelForStep(CurrentStep));
    }

    protected override void OnParametersSet()
    {
        _editContext = new EditContext(GetModelForStep(CurrentStep));
    }

    private IStepModel GetModelForStep(TStep step) =>
        Models.TryGetValue(step, out var model) ? model : throw new InvalidOperationException("Step does not exist");

    private async Task HandleNext()
    {
        if (_editContext.Validate())
        {
            await NextStep();
        }
    }

    private async Task NextStep()
    {
        var currentIndex = _steps.IndexOf(CurrentStep);
        if (currentIndex < _steps.Count - 1)
        {
            CurrentStep = _steps[currentIndex + 1];
            await CurrentStepChanged.InvokeAsync(CurrentStep);
            _editContext = new EditContext(GetModelForStep(CurrentStep));
        }
    }

    private async Task PreviousStep()
    {
        var currentIndex = _steps.IndexOf(CurrentStep);
        if (currentIndex > 0)
        {
            CurrentStep = _steps[currentIndex - 1];
            await CurrentStepChanged.InvokeAsync(CurrentStep);
            _editContext = new EditContext(GetModelForStep(CurrentStep));
        }
    }

    private bool IsFirstStep() => _steps.IndexOf(CurrentStep) == 0;

    private bool IsLastStep() => _steps.IndexOf(CurrentStep) == _steps.Count - 1;
}
