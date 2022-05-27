namespace console_2048;

public class Input
{
    public Command Current;

    public void ReadInput()
    {
        Current = Console.ReadKey().Key switch
        {
            ConsoleKey.LeftArrow => Command.Left,
            ConsoleKey.RightArrow => Command.Right,
            ConsoleKey.UpArrow => Command.Up,
            ConsoleKey.DownArrow => Command.Down,
            ConsoleKey.Enter => Command.Enter,
            ConsoleKey.R => Command.R,
            ConsoleKey.Backspace => Command.Backspace,
            _ => Command.Unknown
        };
    }

    public enum Command
    {
        Unknown,
        Left,
        Right,
        Up,
        Down,
        Enter,
        R,
        Backspace
    }
}