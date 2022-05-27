namespace console_2048;

public static class Debug
{
    private static readonly List<object> _log = new ();
    public static event Action<object>? OnLog; 

    public static void Log(object message)
    {
        _log.Add(message);
        OnLog?.Invoke(message);
    }
}