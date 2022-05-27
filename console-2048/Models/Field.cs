using console_2048.Extensions;

namespace console_2048.Models
{
    public class Field
    {
        public IReadOnlyList<Cell> Cells => _cells;
        public IReadOnlyDictionary<int, List<Cell>> Rows => _rows;
        public int MaxCell => Cells.Max(x => x.Value);
        public StaticData.Field? Data { get; private set; }
        public bool IsFull => !Cells.Any(CanMove);
        private bool CanMove(Cell cell) => CanMoveTop(cell) || CanMoveDown(cell) || CanMoveLeft(cell) || CanMoveRight(cell);
        public bool IsEmpty => true;

        private List<Cell> _cells = new();
        private Dictionary<int, List<Cell>> _rows = new();
        private Dictionary<int, List<Cell>> _columns = new();
        private List<List<Cell>> _linesMoveLeft = new();
        private List<List<Cell>> _linesMoveRight = new();
        private List<List<Cell>> _lineMoveUp = new ();
        private List<List<Cell>> _lineMoveDown = new();
        private Dictionary<Coordinate, Cell> _cellByCoordinate = new();
        private readonly FieldProvider _fieldProvider = new();
        public void Create(StaticData.Field data)
        {
            Data = data;

            _cells = _fieldProvider.GenerateEmpty(data.Rows, data.Columns).ToList();
            AddRandom();
            AddRandom();
        
            SetupField();
        }

        private void SetupField()
        {
            _rows = _cells.GroupBy(cell => cell.Row, cell => cell).ToDictionary(x => x.Key, g => g.ToList());
            _columns = _cells.GroupBy(cell => cell.Column, cell => cell).ToDictionary(x => x.Key, g => g.ToList());
            _linesMoveLeft = _rows.Values.Select(line => line.OrderBy(cell => cell.Column).ToList()).ToList();
            _linesMoveRight = _rows.Values.Select(line => line.OrderByDescending(cell => cell.Column).ToList()).ToList();
            _lineMoveUp = _columns.Values.Select(line => line.OrderBy(cell => cell.Row).ToList()).ToList();
            _lineMoveDown = _columns.Values.Select(line => line.OrderByDescending(cell => cell.Row).ToList()).ToList();
            _cellByCoordinate = _cells.ToDictionary(x => x.Coordinate);
        }

        public MoveResult Move(Input.Command input)
        {
            return input switch
            {
                Input.Command.Left => MoveLeft(),
                Input.Command.Right => MoveRight(),
                Input.Command.Up => MoveUp(),
                Input.Command.Down => MoveDown(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    
        private MoveResult MoveLeft()
        {
            var result = Move(_linesMoveLeft);
            AddRandom();
            return result;
        }
    
        private MoveResult MoveRight()
        {
            var result = Move(_linesMoveRight);
            AddRandom();
            return result;
        }
    
        private MoveResult MoveUp()
        {
            var result = Move(_lineMoveUp);
            AddRandom();
            return result;
        }
    
        private MoveResult MoveDown()
        {
            var result = Move(_lineMoveDown);
            AddRandom();
            return result;
        }

        private void AddRandom()
        {
            var empty = _cells.Where(x => x.IsEmpty).ToList();
            if (!empty.Any())
            {
                return;
            }
        
            for (var i = 0; i < Data!.NextTurnAddCellsCount; i++)
            {
                var rnd1 = new Random().Next(0, empty.Count);
                empty[rnd1].SetValue(2);
            }
        }

        private bool IsMergeAvailable(Cell to, Cell from, IEnumerable<Coordinate> used) =>
            to.Value == from.Value && !used.Any(x => to.Coordinate.Equals(x));

        private MoveResult Move(List<List<Cell>> lines)
        {
            var result = new MoveResult();

            foreach (var line in lines)
            {
                MoveLine(line, result);
            }

            return result;
        }
        
        private void MoveLine(List<Cell> line, MoveResult result)
        {
            var used = new List<Coordinate>();

            foreach (var cell in line)
            {
                if (cell.IsEmpty)
                {
                    continue;
                }

                if (cell == line.First())
                {
                    continue;
                }

                var nextNotEmpty = line.Take(line.IndexOf(cell)).Reverse().FirstOrDefault(x => !x.IsEmpty);

                if (nextNotEmpty is null)
                {
                    line.First().SetValue(cell.Value);
                    cell.SetValue(0);
                    continue;
                }

                if (IsMergeAvailable(nextNotEmpty, cell, used))
                {
                    nextNotEmpty.SetValue(nextNotEmpty.Value * 2);
                    cell.SetValue(0);
                    used.Add(nextNotEmpty.Coordinate);
                    result.Score += nextNotEmpty.Value;

                    continue;
                }

                var beforeNextNotEmpty = line[line.IndexOf(nextNotEmpty) + 1];

                if (cell != beforeNextNotEmpty)
                {
                    beforeNextNotEmpty.SetValue(cell.Value);
                    cell.SetValue(0);
                }
            }
        }

        private bool CanMoveTop(Cell cell)
        {
            if (cell.Coordinate.Row == 0)
            {
                return false;
            }
            var to = _cellByCoordinate[cell.Coordinate.Up()];
            return to.Value == 0 || to.Value == cell.Value;
        }
    
        private bool CanMoveDown(Cell cell)
        {
            if (cell.Coordinate.Row == Data!.Rows - 1)
            {
                return false;
            }
            var to = _cellByCoordinate[cell.Coordinate.Down()];
            return to.Value == 0 || to.Value == cell.Value;
        }
    
        private bool CanMoveLeft(Cell cell)
        {
            if (cell.Coordinate.Column == 0)
            {
                return false;
            }
            var to = _cellByCoordinate[cell.Coordinate.Left()];
            return to.Value == 0 || to.Value == cell.Value;
        }
    
        private bool CanMoveRight(Cell cell)
        {
            if (cell.Coordinate.Column == Data!.Columns - 1)
            {
                return false;
            }
            var to = _cellByCoordinate[cell.Coordinate.Right()];
            return to.Value == 0 || to.Value == cell.Value;
        }
    }
}





