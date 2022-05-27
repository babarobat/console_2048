namespace console_2048.StaticData;

public class Field : Config
{
    public int Rows;
    public int Columns;
    public int StartNotEmptyCount;
    public int NextTurnAddCellsCount;
    public List<Internal.Cell> StartCells = new ();
    public class Internal
    {
        public class Cell
        {
            public int Row;
            public int Column;
            public int Value;

            public Cell(int row, int column, int value)
            {
                Row = row;
                Column = column;
                Value = value;
            }
        }
    }
}

//выбор уровня
//создать в моделе раунд
//сохраннение
//иметь возможность продолжить раунд


