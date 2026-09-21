using abdukulov_talgat.MathGame.Helpers;

namespace abdukulov_talgat.MathGame.Core.Round;

public abstract class RoundBase(int left, int right, Operation operation)
{
    protected const int MinNumber = 0;

    protected const int MaxNumber = 100;

    public int Left { get; protected init; } = left;

    public int Right { get; protected init; } = right;

    public Operation Operation { get; protected init; } = operation;

    public int ActualResult { get; set; }

    protected abstract int Score { get; init; }

    protected abstract int ExpectedResult { get; }

    private bool IsCorrectAnswer => ExpectedResult == ActualResult;

    public int GetScore()
    {
        return IsCorrectAnswer ? Score : 0;
    }

    public override string ToString()
    {
        return $"{Left} {Operation.GetDescription()} {Right} = {ExpectedResult}";
    }
}