namespace console_2048.Models;

public class Cell
{
    public Cell(int value, int row, int column, StaticData.Cell data)
    {
        Value = value;
        Data = data;
        
        _coordinate.Row = row;
        _coordinate.Column = column;
    }

    public StaticData.Cell Data { get; }
    public int Value { get; private set; }
    public int Column => Coordinate.Column;
    public int Row => Coordinate.Row;
    public Coordinate Coordinate => _coordinate;
    public bool IsEmpty => Value == 0;
    private readonly Coordinate _coordinate;
    public void SetValue(int value) => Value = value;

    public override string ToString() => $"[R{Row} C{Column}] = {Value}";
}