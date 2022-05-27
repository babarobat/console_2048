namespace console_2048.Extensions;

public static class CellModelExtensions
{
    public static IEnumerable<Models.Records.Cell> ToRecords(this IEnumerable<Models.Cell> from) => from.Select(ToRecord);
    public static Models.Records.Cell ToRecord(this Models.Cell from) =>  new (from.Row, from.Column, from.Value);
}