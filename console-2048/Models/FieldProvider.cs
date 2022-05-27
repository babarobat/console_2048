using console_2048.StaticData;

namespace console_2048.Models;

public class FieldProvider
{
    private readonly Random _random = new();
    private StaticData.Cell _defaultCell => Configs.Library.CellDefault;
    
    public List<Cell> Restore(IEnumerable<Records.Cell> cells) => GenerateFrom( cells).ToList();

    public List<Cell> GenerateWithRandom(StaticData.Field field)
    {
        var result = GenerateEmpty(field.Rows, field.Columns).ToDictionary(x => x.Coordinate);

        AddStartNotEmptyCells(field, result);

        return result.Values.ToList();
    }

    private void AddStartNotEmptyCells(StaticData.Field field, Dictionary<Coordinate, Cell> result)
    {
        for (var i = 0; i < field.StartNotEmptyCount; i++)
        {
            var randomCoordinate = GetRandomCoordinate(field.Rows, field.Columns);
            result[randomCoordinate].SetValue(2);
        }
    }

    private IEnumerable<Cell> GenerateFrom(IEnumerable<Records.Cell> cells) => cells.Select(cell => new Cell(cell.Value, cell.Row, cell.Column,_defaultCell));
    private Coordinate GetRandomCoordinate(int maxRow, int maxColumn) => new (_random.Next(maxRow),_random.Next(maxColumn));
    public IEnumerable<Cell> GenerateEmpty(int rows, int columns)
    {
        for (var row = 0; row < rows; row++)
        {
            for (var column = 0; column < columns; column++)
            {
                yield return new Cell(0, row, column, _defaultCell);
            }
        }
    }
}