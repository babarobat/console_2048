using System.Text;

namespace console_2048.Views;

public class LogView : ViewBase
{
    private readonly StringBuilder _builder = new();
    public LogView()
    {
        Debug.OnLog += OnLog;
    }
    
    private void OnLog(object message)
    {
        _builder.AppendLine(message.ToString());
    }

    public override void Update() { }
    public override void Draw() => Console.WriteLine(_builder.ToString());
}