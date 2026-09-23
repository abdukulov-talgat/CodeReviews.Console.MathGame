using System.Collections.ObjectModel;

namespace abdukulov_talgat.MathGame.FlowControl;

public class MainMenuState : FlowStateBase, IMenu
{
    private readonly Dictionary<string, MenuItem> _menuItems = new()
    {
        { "1", new MenuItem("Play", () => new DifficultyFlowState()) },
        { "2", new MenuItem("History", () => new HistoryFlowState()) },
        { "3", new MenuItem("Exit", () => new ExitFlowState()) },
    };

    public override void ProcessGameLoop()
    {
        MenuItem menuItem = (this as IMenu).ProcessMenu("Main Menu");
        Context.ChangeState(menuItem.Creator.Invoke());
    }

    public ReadOnlyDictionary<string, MenuItem> MenuItems => _menuItems.AsReadOnly();
}