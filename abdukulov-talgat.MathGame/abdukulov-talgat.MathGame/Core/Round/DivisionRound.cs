namespace abdukulov_talgat.MathGame.Core.Round;

public class DivisionRound : RoundBase
{
    private DivisionRound() : base(0, 0, Operation.Division)
    {
        //TODO: Only integer result. Adjust
        Left = Random.Shared.Next(MinNumber, MaxNumber + 1);
        Right = Random.Shared.Next(MinNumber, MaxNumber + 1);
    }

    protected override int Score => 2;

    protected override int ExpectedResult => Left / Right;

    public static RoundBase Create()
    {
        return new DivisionRound();
    }
}