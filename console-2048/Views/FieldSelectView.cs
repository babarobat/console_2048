using console_2048.Extensions;

namespace console_2048.Views;

public class FieldSelectView : ViewBase, IApplyInput
{
    public FieldSelectViewData Data { get ; private set; }
    private StaticData.Field? _selected;
    
    public void Connect(FieldSelectViewData data)
    {
        Data = data;
        _selected = Data.Fields.First();
    }

    public void ApplyInput(Input.Command command)
    {
        switch (command)
        {
            case Input.Command.Right: SelectNext(); break;
            case Input.Command.Left: SelectPrevious(); break;
            case Input.Command.Enter: HandleSelection(); break;
            case Input.Command.Backspace: Back(); break;
        }
    }

    private void Back() => Data.OnBackPressed.Invoke();
    private void HandleSelection() => Data.OnFieldSelected.Invoke(_selected!);
    private void SelectPrevious() => _selected = Data.Fields.Previous(_selected);
    private void SelectNext() => _selected = Data.Fields.Next(_selected);

    public override void Draw()
    {
        Console.WriteLine("select field size. Press enter to select, backspace to return to main menu");

        foreach (var fieldConfig in Data.Fields)
        {
            DrawButton(fieldConfig);
        }
        Console.WriteLine();

        DrawFieldPreview();
    }

    private void DrawFieldPreview()
    {
        StringBuilder.Clear();

        for (var i = 0; i < _selected!.Rows; i++)
        {
            for (var j = 0; j < _selected.Columns; j++)
            {
                StringBuilder.Append("[]");
            }

            StringBuilder.Append('\n');
        }

        Console.WriteLine(StringBuilder);
    }

    private void DrawButton(StaticData.Field fieldConfig)
    {
        if (fieldConfig == _selected)
        {
            WriteForegroundColorColor(ConsoleColor.Yellow, ButtonCaption(fieldConfig));
        }
        else
        {
            Console.Write(ButtonCaption(fieldConfig));
        }
    }

    private static string ButtonCaption(StaticData.Field fieldConfig)
    {
        return $"[{fieldConfig.Rows}x{fieldConfig.Columns}]";
    }
}

public struct FieldSelectViewData
{
    public Action<StaticData.Field> OnFieldSelected;
    public Action OnBackPressed;
    public List<StaticData.Field> Fields;
}