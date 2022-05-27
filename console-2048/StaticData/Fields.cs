namespace console_2048.StaticData;

public class Fields : Declaration
{
    public Fields()
    {
        Configs = new()
        {
            new Field
            {
                Name = "4x4",
                Rows = 4,
                Columns = 4,
                StartNotEmptyCount = 2,
                NextTurnAddCellsCount = 1,
            },

            new Field
            {
                Name = "3x5",
                Rows = 5,
                Columns = 3,
                StartNotEmptyCount = 2,
                NextTurnAddCellsCount = 1,
            },
            
            new Field
            {
                Name = "5x5",
                Rows = 5,
                Columns = 5,
                StartNotEmptyCount = 2,
                NextTurnAddCellsCount = 1,
            },
        };
    }
}