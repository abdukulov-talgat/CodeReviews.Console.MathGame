namespace abdukulov_talgat.MathGame.Core.Round;

public class MultiplyRound : RoundBase
{
    private MultiplyRound() : base(Random.Shared.Next(MinNumber, MaxNumber + 1),
        Random.Shared.Next(MinNumber, MaxNumber + 1),
        Operation.Multiply)
    {
    }

    protected override int Score { get; init; } = 2;

    protected override int ExpectedResult => Left * Right;

    public static RoundBase Create()
    {
        return new MultiplyRound();
    }
}