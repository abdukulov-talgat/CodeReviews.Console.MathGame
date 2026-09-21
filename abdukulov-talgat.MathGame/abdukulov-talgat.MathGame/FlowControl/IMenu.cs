using System.Collections.ObjectModel;
using abdukulov_talgat.MathGame.Helpers;

namespace abdukulov_talgat.MathGame.UI;

public interface IMenu
{
    ReadOnlyDictionary<string, MenuItem> MenuItems { get; }

    MenuItem ProcessMenu()
    {
        string? userInput = null;
        while (userInput is null || !MenuItems.ContainsKey(userInput))
        {
            Console.WriteLine(string.PadCenter("Play Menu"));
            PrintMenu();
            userInput = Console.ReadLine();
            GameHelpers.AdjustLastLine(userInput);
        }

        return MenuItems[userInput];
    }

    protected void PrintMenu()
    {
        for (int i = 0; i < MenuItems.Values.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {MenuItems.Values.ElementAt(i).Display}");
        }
    }
}