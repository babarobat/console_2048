using System.Text;

namespace console_2048.Views;

public abstract class ViewBase
{
    protected readonly StringBuilder StringBuilder = new();

    public virtual void Update(){}
    public abstract void Draw();
    public virtual void Utilize(){}
    protected void WriteLineForegroundColorColor(ConsoleColor color, string value)
    {
        var currentColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(value); 
        Console.ForegroundColor = currentColor;
    }
    
    protected void WriteForegroundColorColor(ConsoleColor color, string value)
    {
        var currentColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(value); 
        Console.ForegroundColor = currentColor;
    }
    
}