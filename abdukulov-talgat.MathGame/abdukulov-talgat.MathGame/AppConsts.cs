using abdukulov_talgat.MathGame.Core;

namespace abdukulov_talgat.MathGame;

public static class AppConsts
{
    public const int AdjustTypingDelay = 50;

    public const int RoundsPerSession = 5;

    public const int SecondsBeforeExit = 3;

    public static readonly Difficulty Easy = new Difficulty(0, 50, .75f);
    
    public static readonly Difficulty Normal = new Difficulty(0, 100, 1);
    
    public static readonly Difficulty Hard = new Difficulty(0, 200, 1.5f);
    
    public static readonly Difficulty Master = new Difficulty(0, 400, 2f);
}