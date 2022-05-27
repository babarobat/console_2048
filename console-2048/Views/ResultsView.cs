using console_2048.Models;

namespace console_2048.Views;

public class ResultsView : ViewBase
{
    private Model _model;

    public void Connect(Model model)
    {
        _model = model;
    }

    public override void Draw()
    {
        StringBuilder.Clear();
        StringBuilder.AppendLine("Game over!");
        StringBuilder.AppendLine($"Your score is {_model.Round.Score.Value}!");
        StringBuilder.AppendLine($"Record is {_model.Statistic.MaxScore}!");
        StringBuilder.AppendLine($"press R to restart");

        Console.WriteLine(StringBuilder);
    }
}