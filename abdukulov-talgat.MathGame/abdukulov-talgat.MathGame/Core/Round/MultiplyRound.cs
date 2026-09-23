namespace abdukulov_talgat.MathGame.Core.Round;

public class MultiplyRound : RoundBase
{
    private MultiplyRound()
    {
        Operation = Operation.Multiply;
    }

    protected override float ScoreBase => 2;

    protected override int ExpectedResult => Left * Right;

    public static RoundBase Create()
    {
        return new MultiplyRound();
    }
}