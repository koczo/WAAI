namespace WAAI.Core.LocalStorageItems;

public interface IStorageItem<T>
{
    string Key { get; init; }
    T Value { get; set; }
}

public static class StorageItem
{
    public record IsHorizontalMenu : IStorageItem<bool>
    {
        public string Key { get; init; } = nameof(IsHorizontalMenu);
        public bool Value { get; set; }
    }

    public record CurrentTheme : IStorageItem<string>
    {
        public string Key { get; init; } = nameof(CurrentTheme);
        public string Value { get; set; } = string.Empty;
    }
}