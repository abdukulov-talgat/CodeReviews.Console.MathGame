using System.Collections.ObjectModel;
using abdukulov_talgat.MathGame.Core;

namespace abdukulov_talgat.MathGame.FlowControl;

public class DifficultyFlowState : FlowStateBase, IMenu
{
    private readonly Dictionary<string, MenuItem> _menuItems = [];

    public DifficultyFlowState()
    {
        _menuItems.Add("1", new MenuItem("Easy", () => SetDifficulty(AppConsts.Easy)));
        _menuItems.Add("2", new MenuItem("Normal", () => SetDifficulty(AppConsts.Normal)));
        _menuItems.Add("3", new MenuItem("Hard", () => SetDifficulty(AppConsts.Hard)));
        _menuItems.Add("4", new MenuItem("Master", () => SetDifficulty(AppConsts.Master)));
        _menuItems.Add("5", new MenuItem("Back", () => new MainMenuState()));
    }

    public override void ProcessGameLoop()
    {
        MenuItem menuItem = (this as IMenu).ProcessMenu("Choose difficulty");
        Context.ChangeState(menuItem.Creator.Invoke());
    }

    public ReadOnlyDictionary<string, MenuItem> MenuItems => _menuItems.AsReadOnly();

    private FlowStateBase SetDifficulty(Difficulty difficulty)
    {
        Game.Instance.ChangeDifficulty(difficulty);
        return new PlayFlowState();
    }
}