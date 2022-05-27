namespace console_2048.Views;

public class ButtonView : ViewBase, ISelectable
{
    private bool _isSelected;
    private ButtonViewData _data;
    public bool IsEnable = true;

    public override void Draw()
    {
        if (!IsEnable)
        {
            WriteLineForegroundColorColor(ConsoleColor.Gray, _data.Caption);
        }
        else if (_isSelected)
        {
            WriteLineForegroundColorColor(ConsoleColor.Yellow, _data.Caption);
        }
        else
        {
            Console.WriteLine(_data.Caption);
        }
    }

    public void SetSelected(bool isSelected) => _isSelected = isSelected;
    public void HandleSelection() => _data.OnPressed?.Invoke();
    public void Connect(ButtonViewData data) => _data = data;
}