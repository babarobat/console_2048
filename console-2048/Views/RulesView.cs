namespace console_2048.Views;

public class RulesView : ViewBase
{
    public override void Draw()
    {
        StringBuilder.Clear();
        
        StringBuilder.AppendLine("controls: \u2190 \u2191 \u2192 \u2193");
        StringBuilder.Append("main menu: backspace");
        
        Console.WriteLine(StringBuilder);
    }
}