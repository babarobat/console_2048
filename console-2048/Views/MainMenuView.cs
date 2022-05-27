using console_2048.Extensions;

namespace console_2048.Views;

public class MainMenuView : ViewBase, IApplyInput
{
    private readonly ButtonView [] _buttons = { new (), new(), new() };
    private ButtonView ButtonContinue => _buttons[0];
    private ButtonView ButtonNewGame => _buttons[1];
    private ButtonView ButtonLeaderBoard => _buttons[2];
    
    private readonly SelectionController<ButtonView> _selection = new ();

    public void Connect(MainMenuViewData data)
    {
        ButtonContinue.Connect(data.ContinueButtonData);
        ButtonNewGame.Connect(data.NewGameButtonData);
        ButtonLeaderBoard.Connect(data.LeaderboardButtonData);
        
        ButtonContinue.IsEnable = data.IsContinueAvailable;

        _buttons.Where(x => x.IsEnable).ForEach(x => _selection.Add(x));
        _selection.Select(_buttons.First(x => x.IsEnable));
    }
    
    public void ApplyInput(Input.Command command)
    {
        switch (command)
        {
            case Input.Command.Down: SelectNext(); break;
            case Input.Command.Up: SelectPrevious(); break;
            case Input.Command.Enter: HandleSelection(); break;
        }
    }

    private void HandleSelection() => _selection.Current!.HandleSelection();
    private void SelectPrevious() => _selection.Previous();
    private void SelectNext() => _selection.Next();
    public override void Draw() => _buttons.ForEach(x => x.Draw());
}