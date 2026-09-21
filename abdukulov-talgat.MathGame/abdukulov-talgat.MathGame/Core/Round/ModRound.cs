namespace abdukulov_talgat.MathGame.Core.Round;

public class ModRound : RoundBase
{
    private ModRound()
    {
        Operation = Operation.Mod;
    }
    protected override float ScoreBase { get; } = 2;
    protected override int ExpectedResult => Left % Right;
    
    public static RoundBase Create()
    {
        return new ModRound();
    }
}