using console_2048.Extensions;

namespace console_2048.Models;

public class History
{
    public RoundPrint Last { get; } = new();
    public bool IsEmpty => Last.IsEmpty;
    public void Record(IReadOnlyList<Cell> cells, int score, int maxNumber) => Last.MakeRecord(cells.ToRecords().ToList() ,score,maxNumber);
    public void StartNewRecord(StaticData.Field data) => Last.StartNew(data);
}