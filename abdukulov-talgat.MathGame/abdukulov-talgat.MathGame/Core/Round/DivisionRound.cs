namespace abdukulov_talgat.MathGame.Core.Round;

public class DivisionRound : RoundBase
{
    private DivisionRound()
    {
        int minDivisor = Math.Max(1, Difficulty.MinNumber);
        int maxDivisor = (int)Math.Sqrt(Difficulty.MaxNumber);
        maxDivisor = (int)(maxDivisor * 1.5);

        Right = Random.Shared.Next(minDivisor, maxDivisor + 1);
        int maxQuotient = Difficulty.MaxNumber / Right;
        int quotient = Random.Shared.Next(1, maxQuotient + 1);
        Left = Right * quotient;
        Operation = Operation.Division;
    }

    protected override float ScoreBase => 2;

    protected override int ExpectedResult => Left / Right;

    public static RoundBase Create()
    {
        return new DivisionRound();
    }
}