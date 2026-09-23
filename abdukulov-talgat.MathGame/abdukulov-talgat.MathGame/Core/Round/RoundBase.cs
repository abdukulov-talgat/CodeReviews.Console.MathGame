using abdukulov_talgat.MathGame.Helpers;

namespace abdukulov_talgat.MathGame.Core.Round;

public abstract class RoundBase
{
    public event Action? OnRoundFinished;

    protected RoundBase()
    {
        Difficulty = Game.Instance.Difficulty;
        Left = Random.Shared.Next(Difficulty.MinNumber, Difficulty.MaxNumber + 1);
        Right = Random.Shared.Next(Difficulty.MinNumber, Difficulty.MaxNumber + 1);
    }

    private bool _gotAnswer;

    public int Left { get; protected init; }

    public int Right { get; protected init; }

    public Operation Operation { get; protected init; }

    public int ActualResult
    {
        get;
        set
        {
            if (_gotAnswer) return;
            _gotAnswer = true;
            field = value;
            OnRoundFinished?.Invoke();
            OnRoundFinished = null;
        }
    }

    public Difficulty Difficulty { get; init; }

    protected abstract float ScoreBase { get; }

    protected abstract int ExpectedResult { get; }

    private bool IsCorrectAnswer => ExpectedResult == ActualResult;

    public float GetScore()
    {
        return IsCorrectAnswer ? ScoreBase * Difficulty.ScoreMultiplier : 0;
    }

    public override string ToString()
    {
        return $"{Left} {Operation.GetDescription()} {Right} = {ExpectedResult}";
    }
}