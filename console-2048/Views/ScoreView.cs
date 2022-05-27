namespace console_2048.Views;
public class ScoreView : ViewBase
{
    private Models.Model _model;
    public void Connect(Models.Model model)
    {
        _model = model;
    }

    public override void Draw()
    {
        StringBuilder.Clear();
        StringBuilder.AppendLine($"score: {_model.Round.Score.Value}/record: {_model.Statistic.MaxScore}");
        StringBuilder.Append($"max cell: {_model.Round.Score.MaxNumber}/record: {_model.Statistic.MaxNumber}");
        Console.WriteLine(StringBuilder);
    }
}