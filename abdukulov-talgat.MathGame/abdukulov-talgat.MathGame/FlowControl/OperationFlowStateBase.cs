using abdukulov_talgat.MathGame.Core;
using abdukulov_talgat.MathGame.Core.Round;
using abdukulov_talgat.MathGame.Helpers;

namespace abdukulov_talgat.MathGame.FlowControl;

public abstract class OperationFlowStateBase : FlowStateBase
{
    public override void ProcessGameLoop()
    {
        Operation operation = GetRelevantOperation();
        Console.WriteLine(string.PadCenter($"Starting {operation.GetDescription()} Session"));
        float score = PlaySession(operation);
        Console.WriteLine(string.PadCenter($"Session is over. Your score: {score:F2}"));

        PlayFlowState playFlowState = new();
        Context.ChangeState(playFlowState);
    }

    private float PlaySession(Operation operation)
    {
        foreach (RoundBase round in Game.Instance.GetSessionRounds(operation)) PlayRound(round);

        return Game.Instance.GetLastSessionScore();
    }

    private void PlayRound(RoundBase round)
    {
        string? strAnswer = PromptUserForAnswer(round);

        int number;
        while (!int.TryParse(strAnswer, out number))
        {
            Console.WriteLine("Incorrect Input. Only numbers acceptable.");
            strAnswer = PromptUserForAnswer(round);
        }

        round.ActualResult = number;
    }

    private string? PromptUserForAnswer(RoundBase round)
    {
        Console.Write($"{round.Left} {round.Operation.GetDescription()} {round.Right} = ");
        return Console.ReadLine();
    }

    public abstract Operation GetRelevantOperation();
}