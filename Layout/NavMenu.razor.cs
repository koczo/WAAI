using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace WAAI.Layout;

public partial class NavMenu
{
    [Inject] private ILocalStorageService LocalStorage { get; set; } = default!;

    private bool _horizontalMenu;

    protected override async Task OnInitializedAsync()
    {
        _horizontalMenu = await LocalStorage.GetItemAsync<bool>("horizontalMenu");
    }
}
