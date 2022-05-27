namespace console_2048.Views;

public class View
{
    private readonly Dictionary<Type, ViewBase> _views = new();
    private readonly List<ViewBase> _active = new();
    public View()
    {
        _views[typeof(ScoreView)] = new ScoreView();
        _views[typeof(FieldView)] = new FieldView();
        _views[typeof(RulesView)] = new RulesView();
        //_views[typeof(LastCommandView)] = new LastCommandView(model.Commands);
        _views[typeof(LogView)] = new LogView();
        _views[typeof(ResultsView)] = new ResultsView();
        _views[typeof(MainMenuView)] = new MainMenuView();
        _views[typeof(FieldSelectView)] = new FieldSelectView();
    }

    public T Show<T>() where T : ViewBase
    {
        var view = _views[typeof(T)];
        _active.Add(view);
        return (T)view;
    }
    public void Clear()
    {
        foreach (var view in _active)
        {
            view.Utilize();
        }
        _active.Clear();
    }

    public void Update()
    {
        foreach (var view in _active)
        {
            view.Update();
        }

        Console.Clear();
        foreach (var view in _active)
        {
            view.Draw();
        }
    }
}