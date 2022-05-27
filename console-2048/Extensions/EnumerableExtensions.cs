namespace console_2048.Extensions;

public static class EnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> sequence, Action<int, T> action)
    {
        var i = 0;
        foreach (var item in sequence)
        {
            action(i, item);
            i++;
        }
    }
    
    public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
    {
        foreach (var item in sequence)
        {
            action(item);
        }
    }
    
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? target) => target == null || !target.Any();

    public static T Next<T>(this IEnumerable<T> target, T current)
    {
        var list = target.ToList();
        if ( EqualityComparer<T>.Default.Equals(list.Last(),current))
        {
            return list.First();
        }

        var currentIndex = list.IndexOf(current);
        return list[currentIndex + 1];
    }
    
    public static T Previous<T>(this IEnumerable<T> target, T current)
    {
        if (target.IsNullOrEmpty())
        {
            throw new InvalidOperationException();
        }
        
        var list = target.ToList();
        if (!list.Contains(current))
        {
            throw new ArgumentOutOfRangeException();
        }
        
        if (EqualityComparer<T>.Default.Equals(list.First(),current))
        {
            return list.Last();
        }

        var currentIndex = list.IndexOf(current);
        return list[currentIndex - 1];
    }
}