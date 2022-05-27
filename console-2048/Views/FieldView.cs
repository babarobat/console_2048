using System.Text;
using console_2048.Extensions;

namespace console_2048.Views;

public class FieldView : ViewBase
{
    private readonly StringBuilder _stringBuilder = new ();
    private readonly List<List<CellView>> _cellViews = new ();
    private Models.Field _field;
    
    public void Connect(Models.Field field)
    {
        _field = field;
        
        for (var i = 0; i < _field.Rows.Count; i++)
        {
            var raw = _field.Rows[i];
            _cellViews.Add(new List<CellView>());
            foreach (var cell in raw)
            {
                _cellViews[i].Add(new CellView(cell));
            }
        }
    }

    public override void Update()
    {
        foreach (var raw in _cellViews)
        {
            foreach (var cell in raw)
            {
                cell.Update();
                cell.SetSize(GetMaxCellSize());
            }
        }
    }

    private int GetMaxCellSize()
    {
        return _field.Cells.Max(x => x.Value.Length());
    }

    public override void Draw()
    {
        _stringBuilder.Clear();

        foreach (var raw in _cellViews)
        {
            Console.Write("   ");
            foreach (var cell in raw)
            {
                cell.Draw();
            }
            Console.WriteLine();
        }
    }

    public override void Utilize()
    {
        _cellViews.Clear();
        
        base.Utilize();
    }
}
