namespace console_2048.Models;

public class Model
{
    public Round Round { get; } = new();
    public Statistic Statistic { get; } = new();

    public void RoundStartNew(StaticData.Field data)
    {
        Round.StartNew(data);
    }

    public void RoundMakeTurn(Input.Command command)
    {
        Round.RoundMakeTurn(command);
        Statistic.Update(Round.Score.Value, Round.Score.MaxNumber);
    }
}

public class Statistic
{
    public int MaxScore { get; private set; }
    public int MaxNumber { get; private set;}

    public void Update(int score, int number)
    {
        MaxScore = Math.Max(score, MaxScore);
        MaxNumber = Math.Max(number, MaxNumber);
    }
}