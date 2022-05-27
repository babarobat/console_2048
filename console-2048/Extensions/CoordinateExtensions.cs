using console_2048.Models;

namespace console_2048.Extensions;

public static class CoordinateExtensions
{
    public static Coordinate Up(this Coordinate from) => new Coordinate(from.Row - 1, from.Column);
    public static Coordinate Down(this Coordinate from) => new Coordinate(from.Row + 1, from.Column);
    public static Coordinate Left(this Coordinate from) => new Coordinate(from.Row , from.Column -1);
    public static Coordinate Right(this Coordinate from) => new Coordinate(from.Row, from.Column + 1);
}