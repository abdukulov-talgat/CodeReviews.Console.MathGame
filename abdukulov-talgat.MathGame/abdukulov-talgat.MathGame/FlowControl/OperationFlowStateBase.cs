using abdukulov_talgat.MathGame.Core;
using abdukulov_talgat.MathGame.Core.Round;
using abdukulov_talgat.MathGame.Helpers;

namespace abdukulov_talgat.MathGame.UI;

public abstract class OperationFlowStateBase : FlowStateBase, IOperationProvider
{
    public override void ProcessGameLoop()
    {
        Operation operation = GetRelevantOperation();
        Console.WriteLine(string.PadCenter($"Starting {operation.GetDescription()} Session"));
        int score = PlaySession(operation);
        Console.WriteLine(string.PadCenter($"Session is over. Your score: {score}"));

        PlayFlowState playFlowState = new();
        Context.ChangeState(playFlowState);
    }

    private int PlaySession(Operation operation)
    {
        Game game = Context.GetGame();
        foreach (RoundBase round in game.GetSessionRounds(operation)) PlayRound(round);

        return game.GetLastSessionScore();
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