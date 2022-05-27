using console_2048.Models;

namespace console_2048.Extensions;

public static class CellViewExtensions
{
    public static ConsoleColor GetConsoleColor(this Cell target)
    {
        return target.Data.GetColor(target.Value);
    }
}