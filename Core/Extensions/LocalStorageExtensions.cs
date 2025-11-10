using Blazored.LocalStorage;
using WAAI.Core.LocalStorageItems;

namespace WAAI.Core.Extensions;

public static class LocalStorageExtensions
{
    public static async ValueTask SetItemAsync<T>(this IStorageItem<T> item, ILocalStorageService localStorage,
        CancellationToken cancellationToken = default)
    {
        await localStorage.SetItemAsync(item.Key, item.Value, cancellationToken);
    }

    public static async ValueTask InitItemAsync<T>(this IStorageItem<T?> item, ILocalStorageService localStorage,
        T? defaultValue = default, CancellationToken cancellationToken = default)
    {
        item.Value = await localStorage.ContainKeyAsync(item.Key, cancellationToken)
            ? await localStorage.GetItemAsync<T>(item.Key, cancellationToken)
            : defaultValue;
    }
}