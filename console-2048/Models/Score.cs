namespace console_2048.Models;

public class Score
{
    public int Value { get; private set; }
    public int MaxNumber { get; private set; }

    public void Update(int score, int maxCell)
    {
        Value += score;
        MaxNumber = Math.Max(MaxNumber, maxCell);
    }

    public void Reset()
    {
        Value = 0;
        MaxNumber = 0;
    }
}