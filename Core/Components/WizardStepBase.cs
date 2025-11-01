using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace WAAI.Core.Components;

public abstract class WizardStepBase<TModel> : ComponentBase where TModel : class, new()
{
    [CascadingParameter] public EditContext EditContext { get; set; } = null!;
    
    protected TModel Model => (TModel)EditContext.Model;
}
