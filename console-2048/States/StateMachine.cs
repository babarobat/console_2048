using console_2048.Models;
using console_2048.Views;

namespace console_2048.States;

public class StateMachine
{
    private State? _current;
    private readonly IReadOnlyDictionary<Type, State> _states;

    public StateMachine(Model model, View view, Input input)
    {
        _states = new Dictionary<Type, State>
        {
            [typeof(State.Init)] = new State.Init(this),
            [typeof(State.MainMenu)] = new State.MainMenu(this, model, view, input),
            [typeof(State.GamePlay)] = new State.GamePlay(this, model, view, input),
            [typeof(State.Results)] = new State.Results(this, model, view, input),
        };
    }

    public void Set<TState>() where TState : State
    {
        _current?.Exit();
        _current = _states[typeof(TState)];
        _current.Enter();
    }

    public void Set<TState, TStateContext>(TStateContext context) where TState : State.WithPayload<TStateContext>
    {
        _current?.Exit();
        var state = (TState)_states[typeof(TState)];
        state.SetContext(context);
        _current = state;
        _current.Enter();
    }
}