using abdukulov_talgat.MathGame.FlowControl;
using abdukulov_talgat.MathGame.Helpers;

namespace abdukulov_talgat.MathGame;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine(string.PadCenter());
        Console.WriteLine(string.PadCenter("Math Game"));
        Console.WriteLine(string.PadCenter());
        Console.WriteLine("\n");

        MainMenuState mainMenuState = new();
        GameFlowContext context = new(mainMenuState);

        context.StartGameLoop();

        Console.WriteLine(string.PadCenter("Goodbye..."));
        Thread.Sleep(TimeSpan.FromSeconds(1));
    }
}