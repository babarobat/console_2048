using console_2048.Extensions;
using console_2048.Models;

namespace console_2048.Views;

public class CellView : ViewBase
{
    private readonly Models.Cell _cell;
    private int _size;

    public CellView(Models.Cell cell)
    {
        _cell = cell;
    }

    public override void Draw()
    {
        StringBuilder.Clear();
        
        StringBuilder.Append('[');
        var addSpaces = MathF.Max(0, _size - _cell.Value.Length());
        for (var i = 0; i < addSpaces; i++)
        {
            StringBuilder.Append(' ');
        }
        StringBuilder.Append(_cell.Value);
        StringBuilder.Append(']');
        
        WriteForegroundColorColor(_cell.GetConsoleColor(), StringBuilder.ToString());
    }

    public void SetSize(int size)
    {
        _size = size;
    }
}

