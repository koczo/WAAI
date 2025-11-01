using Ardalis.SmartEnum;
using Microsoft.AspNetCore.Components;

namespace WAAI.Core.Components;

public partial class ProgressStepper<TStep> where TStep : SmartEnum<TStep>
{
    [Parameter] public required TStep CurrentStep { get; set; }

    private string GetStepClass(TStep step) =>
        CurrentStep >= step
            ? "w-10 h-10 rounded-full bg-indigo-600 text-white flex items-center justify-center font-bold"
            : "w-10 h-10 rounded-full bg-gray-300 text-gray-600 flex items-center justify-center font-bold";

    private string GetStepTextClass(TStep step) =>
        CurrentStep >= step ? "font-semibold text-indigo-600" : "text-gray-500";

    private string GetLineClass(TStep step) =>
        CurrentStep > step ? "bg-indigo-600" : "bg-gray-300";
}
