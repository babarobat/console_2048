using console_2048.Models;
using console_2048.States;
using console_2048.Views;

namespace console_2048;

public class Game
{
    private readonly StateMachine _state;

    public Game()
    {
        _state = new StateMachine(new Model(), new View(), new Input());
    }

    public void Start()
    {
        _state.Set<State.Init>();
    }
}