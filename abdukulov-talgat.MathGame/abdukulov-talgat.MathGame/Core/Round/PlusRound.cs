namespace abdukulov_talgat.MathGame.Core.Round;

public class PlusRound : RoundBase
{
    private PlusRound()
    {
        Operation = Operation.Plus;
    }

    protected override float ScoreBase => 1;

    protected override int ExpectedResult => Left + Right;

    public static RoundBase Create()
    {
        return new PlusRound();
    }
}