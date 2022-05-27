namespace console_2048.Extensions;

public static class IntExtensions
{
    public static int Length(this int n)
    {
        if (n == 0)
        {
            return 1;
        }
        var count = 0;
        while (n != 0)
        {
            n /= 10;
            ++count;
        }
        return count;
    }
}