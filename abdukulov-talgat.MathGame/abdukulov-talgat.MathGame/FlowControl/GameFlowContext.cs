using System.Diagnostics.CodeAnalysis;

namespace abdukulov_talgat.MathGame.FlowControl;

public class GameFlowContext
{
    private FlowStateBase _currentState;

    private bool _wantToExit;

    public GameFlowContext(FlowStateBase initialState)
    {
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

    public void Exit()
    {
        _wantToExit = true;
    }
}