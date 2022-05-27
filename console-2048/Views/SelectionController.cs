using console_2048.Extensions;

namespace console_2048.Views;

public class SelectionController<T> where T:ISelectable
{
    public T? Current { get; private set; }
    private readonly List<T> _all = new();

    public void Add(T selectable)
    {
        _all.Add(selectable);
    }

    public void Select(T selectable)
    {
        Current = selectable;
        UpdateSelection();
    }
    
    public void Next()
    {
        Current = _all.Next(Current);
        UpdateSelection();
    }

    public void Previous()
    {
        Current = _all.Previous(Current);
        UpdateSelection();
    }

    private void UpdateSelection()
    {
        foreach (var selectable in _all)
        {
            var entry = selectable;
            entry.SetSelected(EqualityComparer<T>.Default.Equals(Current, selectable));
        }
    }

    public void Clear() => _all.Clear();
}