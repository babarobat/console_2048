using console_2048.Models;
using console_2048.StaticData;
using console_2048.Views;
using Field = console_2048.StaticData.Field;

namespace console_2048.States;

public abstract class State
{
    public virtual void Enter() { }
    public virtual void Exit() { }

    public abstract class WithPayload<TPayload> : State
    {
        public abstract void SetContext(TPayload context);
    }

    public class GamePlay : WithPayload<GamePlay.Context>
    {
        private enum InternalState
        {
            HandlingInput,
            Results,
            Back
        }
        
        public abstract class Context
        {
            public class New : Context { public Field? Field;}
            public class Continue : Context { }
        }
        
        private readonly Model _model;
        private readonly View _view;
        private readonly Input _input;
        private readonly StateMachine _state;
        private Context? _context;
        private InternalState _internalState;

        private readonly HashSet<Input.Command> _validFieldCommands = new()
        {
            Input.Command.Down, Input.Command.Up, Input.Command.Left, Input.Command.Right
        };

        public GamePlay(StateMachine state, Model model, View view, Input input)
        {
            _model = model;
            _view = view;
            _input = input;
            _state = state;
        }

        public override void SetContext(GamePlay.Context context) => _context = context;

        public override void Enter()
        {
            _internalState = InternalState.HandlingInput;
            
            switch (_context)
            {
                case GamePlay.Context.Continue _: throw new NotImplementedException(); break;
                case GamePlay.Context.New context: _model.RoundStartNew(context.Field!); break;
                default: throw new ArgumentOutOfRangeException(nameof(_context));
            }

            _view.Clear();
            _view.Show<ScoreView>().Connect(_model);
            _view.Show<FieldView>().Connect(_model.Round.Field);
            _view.Show<RulesView>();

            while (_internalState == InternalState.HandlingInput)
            {
                _view.Update();
                _input.ReadInput();

                if (_input.Current == Input.Command.Backspace)
                {
                    _internalState = InternalState.Back;
                    continue;
                }
                
                if (_validFieldCommands.Contains(_input.Current))
                {
                    _model.RoundMakeTurn(_input.Current);
                }

                if (_model.Round.Field.IsFull)
                {
                    _internalState = InternalState.Results;
                }
            }

            switch (_internalState)
            {
                case InternalState.Results: _state.Set<State.Results>(); break;
                case InternalState.Back: _state.Set<State.MainMenu>(); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        public override void Exit()
        {
            _view.Clear();
            _internalState = default;
            
            base.Exit();
        }
    }

    public class Results : State
    {
        private readonly View _view;
        private readonly Input _input;
        private readonly StateMachine _state;
        private readonly Model _model;

        public Results(StateMachine state, Model model, View view, Input input)
        {
            _view = view;
            _input = input;
            _model = model;
            _state = state;
        }

        public override void Enter()
        {
            _view.Clear();

            _view.Show<ResultsView>().Connect(_model);
            _view.Show<FieldView>().Connect(_model.Round.Field);

            while (_input.Current != Input.Command.R)
            {
                _view.Update();
                _input.ReadInput();
            }

            _state.Set<GamePlay, GamePlay.Context>(new GamePlay.Context.New{Field = _model.Round.Field.Data!});
        }

        public override void Exit()
        {
            _view.Clear();
            
            base.Exit();
        }
    }

    public class Init : State
    {
        private readonly StateMachine _state;
        public Init(StateMachine state) => _state = state;
        public override void Enter() => _state.Set<State.MainMenu>();
    }

    public class MainMenu : State
    {
        private readonly View _view;
        private readonly Model _model;
        private readonly Input _input;
        private readonly StateMachine _state;
        private InternalState _internalState;
        private MainMenuView? _mainMenuView;
        private FieldSelectView? _fieldSelectView;
        private IApplyInput? _applyInput;
        private StaticData.Field? _selectedField;

        private enum InternalState
        {
            HandlingInput,
            Continue,
            NewGame
        }

        public MainMenu(StateMachine state, Model model, View view, Input input)
        {
            _state = state;
            _model = model;
            _view = view;
            _input = input;
        }

        public override void Enter()
        {
            _internalState = InternalState.HandlingInput;

            ShowMainMenu();
            
            while (_internalState == InternalState.HandlingInput)
            {
                _view.Update();
                _input.ReadInput();
                _applyInput!.ApplyInput(_input.Current);
            }

            switch (_internalState)
            {
                case InternalState.Continue: ContinueGame(); break;
                case InternalState.NewGame: StartNewGame(); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void StartNewGame() => _state.Set<State.GamePlay, GamePlay.Context>(new GamePlay.Context.New{ Field = _selectedField!});
        private void ContinueGame() => _state.Set<State.GamePlay, GamePlay.Context>(new GamePlay.Context.Continue());

        private void ShowMainMenu()
        {
            _view.Clear();
            _mainMenuView = _view.Show<MainMenuView>();
            _mainMenuView.Connect(new()
            {
                ContinueButtonData = new () { OnPressed =  OnContinuePressed, Caption = "continue" },
                NewGameButtonData = new () { OnPressed = OnNewGamePressed, Caption = "new game" },
                LeaderboardButtonData = new () { OnPressed = OnLeaderboardPressed, Caption = "leaderboard" },
                IsContinueAvailable = !_model.Round.IsEmpty,
            });
            _applyInput = _mainMenuView;
        }

        private void OnLeaderboardPressed() => throw new NotImplementedException();
        private void OnContinuePressed() => throw new NotImplementedException();
        private void OnNewGamePressed() => ShowFieldSelectMenu();
        private void OnBackFromFieldSelect() => ShowMainMenu();

        private void OnFieldSelected(Field selectedField)
        {
            _selectedField = selectedField;
            _internalState = InternalState.NewGame;
        }

        private void ShowFieldSelectMenu()
        {
            _view.Clear();
            _fieldSelectView = _view.Show<FieldSelectView>();
            _fieldSelectView.Connect(new ()
            {
                Fields = Configs.Library.FieldsAll,
                OnFieldSelected = OnFieldSelected,
                OnBackPressed = OnBackFromFieldSelect,

            });
            _applyInput = _fieldSelectView;
        }

        public override void Exit() => _view.Clear();
    }
}