using abdukulov_talgat.MathGame.Core;
using abdukulov_talgat.MathGame.Helpers;

namespace abdukulov_talgat.MathGame.FlowControl;

public class HistoryFlowState : FlowStateBase
{
    public override void ProcessGameLoop()
    {
        Console.WriteLine(string.PadCenter("Previous Sessions"));
        PrintHistory(Game.Instance.GetSessionsHistory());
        Context.ChangeState(new MainMenuState());
    }

    private void PrintHistory(IReadOnlyList<GameSession> history)
    {
        if (history.Count == 0)
        {
            Console.WriteLine("There is no games before :(");
            return;
        }

        for (int i = 0; i < history.Count; i++)
        {
            GameSession session = history[i];
            Console.WriteLine($"{i + 1}) Score: {session.TotalScore:F2}\tTime spent: {session.SecondsSpent:F2}");
        }
    }
}