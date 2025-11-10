using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using WAAI.Core.Extensions;
using WAAI.Core.LocalStorageItems;

namespace WAAI.Layout;

public partial class NavMenu
{
    [Inject] private ILocalStorageService LocalStorage { get; set; } = default!;

    private readonly StorageItem.IsHorizontalMenu _horizontalMenu = new();

    protected override async Task OnInitializedAsync()
    {
        await _horizontalMenu.InitItemAsync(LocalStorage);
    }
}
