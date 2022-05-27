namespace console_2048.Models;

public struct Coordinate
{
    public int Row { get; set; }
    public int Column { get; set; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }
    public bool Equals(Coordinate other) => Column == other.Column && Row == other.Row;
    public override bool Equals(object? obj) => obj is Coordinate other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(Row, Column);
}