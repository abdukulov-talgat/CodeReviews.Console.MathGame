namespace abdukulov_talgat.MathGame.Core.Round;

public class DivisionRound : RoundBase
{
    private DivisionRound() : base(0, 0, Operation.Division)
    {
        int minDivisor = Math.Max(1, MinNumber);
        int maxDivisor = (int)Math.Sqrt(MaxNumber);
        maxDivisor = (int)(maxDivisor * 1.5);

        Right = Random.Shared.Next(minDivisor, maxDivisor + 1);
        int maxQuotient = MaxNumber / Right;
        int quotient = Random.Shared.Next(1, maxQuotient + 1);
        Left = Right * quotient;
    }

    protected override int Score => 2;

    protected override int ExpectedResult => Left / Right;

    public static RoundBase Create()
    {
        return new DivisionRound();
    }
}