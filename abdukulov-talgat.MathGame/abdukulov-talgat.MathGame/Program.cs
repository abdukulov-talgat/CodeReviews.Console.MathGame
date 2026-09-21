using abdukulov_talgat.MathGame.Helpers;
using abdukulov_talgat.MathGame.UI;

namespace abdukulov_talgat.MathGame;

internal static class Program
{
    private const int RoundsPerSession = 5;

    private static void Main()
    {
        Console.WriteLine(string.PadCenter());
        Console.WriteLine(string.PadCenter("Math Game"));
        Console.WriteLine(string.PadCenter());
        Console.WriteLine("\n");

        MainMenuState mainMenuState = new();
        GameFlowContext context = new(RoundsPerSession, mainMenuState);

        context.StartGameLoop();

        Console.WriteLine(string.PadCenter("Goodbye..."));
        Thread.Sleep(TimeSpan.FromSeconds(1));
    }
}