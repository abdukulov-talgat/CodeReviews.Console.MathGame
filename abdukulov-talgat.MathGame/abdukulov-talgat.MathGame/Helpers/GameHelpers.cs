using System.Drawing;

namespace abdukulov_talgat.MathGame.Helpers;

public static class GameHelpers
{
    public static void AdjustLastLine(
        string? str, string prefix = "You: ", ConsoleColor color = ConsoleColor.DarkMagenta)
    {
        (int _, int top) = Console.GetCursorPosition();
        Console.SetCursorPosition(0, top - 1);
        Console.ForegroundColor = color;
        string newMessage = $"{prefix}{str}";
        foreach (char c in newMessage)
        {
            Console.Write(c);
            Thread.Sleep(50); //TODO: Fix Magic Number
        }
        Console.WriteLine();
        Console.ResetColor();
    }
}