namespace abdukulov_talgat.MathGame.Core.Round;

public class PlusRound : RoundBase
{
    private PlusRound() : base(Random.Shared.Next(MinNumber, MaxNumber + 1),
        Random.Shared.Next(MinNumber, MaxNumber + 1),
        Operation.Plus)
    {
    }

    protected override int Score => 1;

    protected override int ExpectedResult => Left + Right;

    public static RoundBase Create()
    {
        return new PlusRound();
    }
}