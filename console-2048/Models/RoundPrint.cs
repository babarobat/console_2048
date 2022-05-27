using console_2048.Extensions;

namespace console_2048.Models;

public class RoundPrint
{
    public int Score;
    public int MaxCell;
    public List<Records.Cell>? Cells;
    public StaticData.Field? Data;
    public bool IsEmpty => Data != null && !Cells.IsNullOrEmpty();

    public void StartNew(StaticData.Field data)
    {
        Clear();
        
        Data = data;
    }

    public void MakeRecord(List<Records.Cell> cells, int score, int maxCell)
    {
        Score = score;
        MaxCell = maxCell;
        Cells = cells;
    }
    
    public void Clear()
    {
        Score = default;
        MaxCell = default;
        Cells?.Clear();
        Data = default;
    }
}

