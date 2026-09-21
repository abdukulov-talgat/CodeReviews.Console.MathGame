using System.Diagnostics.CodeAnalysis;
using abdukulov_talgat.MathGame.Core;
using abdukulov_talgat.MathGame.Core.Round;
using abdukulov_talgat.MathGame.Helpers;

namespace abdukulov_talgat.MathGame.UI;

public class GameFlowContext
{
    private readonly Game _game;

    private FlowStateBase _currentState;

    private bool _wantToExit;

    public GameFlowContext(int roundsPerSession, FlowStateBase initialState)
    {
        _game = new Game(roundsPerSession);
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

    public Core.Game GetGame() => _game;

    public void Exit()
    {
        _wantToExit = true;
    }

    private bool WantToExit(string? str)
    {
        return string.Equals(str, "exit", StringComparison.InvariantCultureIgnoreCase);
    }
}