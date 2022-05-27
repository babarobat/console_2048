namespace console_2048.StaticData;

public class Cells : Declaration
{
    public Cells()
    {
        Configs = new()
        {
            
            new Cell
            {
                Name = "default",
                Colors = new()
                {
                    [0] = ConsoleColor.DarkGray,
                    [2] = ConsoleColor.Yellow,
                    [4] = ConsoleColor.Red,
                    [8] = ConsoleColor.Green,
                    [16] = ConsoleColor.Cyan,
                    [32] = ConsoleColor.Blue,
                    [64] = ConsoleColor.DarkGreen,
                    [128] = ConsoleColor.DarkCyan,
                    [256] = ConsoleColor.DarkMagenta,
                    [512] = ConsoleColor.DarkRed,
                }
            }
        };
    }
}