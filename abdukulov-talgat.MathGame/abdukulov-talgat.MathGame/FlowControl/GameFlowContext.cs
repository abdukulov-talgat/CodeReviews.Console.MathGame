using System.Diagnostics.CodeAnalysis;
using abdukulov_talgat.MathGame.Core;

namespace abdukulov_talgat.MathGame.FlowControl;

public class GameFlowContext
{
    private readonly Game _game;

    private FlowStateBase _currentState;

    private bool _wantToExit;

    public GameFlowContext(FlowStateBase initialState)
    {
        _game = new Game();
        ChangeState(initialState);
    }

    public void StartGameLoop()
    {
        while (!_wantToExit)
        {
            _currentState.ProcessGameLoop();
            Console.WriteLine();
        }
    }

    [MemberNotNull(nameof(_currentState))]
    public void ChangeState(FlowStateBase newState)
    {
        _currentState = newState;
        _currentState.SetContext(this);
    }

    public Game GetGame() => _game;

    public void Exit()
    {
        _wantToExit = true;
    }
}