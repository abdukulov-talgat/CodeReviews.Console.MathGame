namespace abdukulov_talgat.MathGame.Core.Round;

public class MinusRound : RoundBase
{
    private MinusRound()
    {
        Operation = Operation.Minus;
    }

    protected override float ScoreBase => 1;

    protected override int ExpectedResult => Left - Right;

    public static RoundBase Create()
    {
        return new MinusRound();
    }
}