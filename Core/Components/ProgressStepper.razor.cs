using Ardalis.SmartEnum;
using Microsoft.AspNetCore.Components;

namespace WAAI.Core.Components;

public partial class ProgressStepper<TStep> where TStep : SmartEnum<TStep>
{
    [Parameter] public required TStep CurrentStep { get; set; }
}