namespace abdukulov_talgat.MathGame.Core.Round;

public class MinusRound : RoundBase
{
    private MinusRound() : base(Random.Shared.Next(MinNumber, MaxNumber + 1),
        Random.Shared.Next(MinNumber, MaxNumber + 1),
        Operation.Minus)
    {
    }

    protected override int Score { get; init; } = 1;

    protected override int ExpectedResult => Left - Right;

    public static RoundBase Create()
    {
        return new MinusRound();
    }
}