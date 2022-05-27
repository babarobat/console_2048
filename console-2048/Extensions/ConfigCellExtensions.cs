using console_2048.StaticData;

namespace console_2048.Extensions;

public static class ConfigCellExtensions
{
    public static ConsoleColor GetColor(this Cell target, int value)
    {
        var max = target.Colors.Max(x => x.Key);
        return value > max ? target.Colors[max] : target.Colors[value];
    }
}