namespace console_2048.Models;

public class Round
{
    public Field Field { get; } = new ();
    public Score Score { get; } = new ();
    public bool IsCompleted => Field.IsFull;
    public bool IsEmpty => Field.IsEmpty;

    public void RoundMakeTurn(Input.Command command)
    {
        var moveResult = Field.Move(command);
        if (moveResult.Score > 0)
        {
            Score.Update(moveResult.Score, Field.MaxCell);
        }
    }

    public void StartNew(StaticData.Field data)
    {
        Score.Reset();
        Field.Create(data);
    }
    
}