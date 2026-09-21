using System.Collections.ObjectModel;
using abdukulov_talgat.MathGame.Core;
using abdukulov_talgat.MathGame.Helpers;

namespace abdukulov_talgat.MathGame.FlowControl;

public class PlayFlowState : FlowStateBase, IMenu
{
    private readonly Dictionary<string, MenuItem> _menuItems = new()
    {
        { "1", new MenuItem(Display: Operation.Plus.GetDescription(), () => new PlusOperationFlow()) },
        { "2", new MenuItem(Display: Operation.Minus.GetDescription(), () => new MinusOperationFlow()) },
        { "3", new MenuItem(Display: Operation.Multiply.GetDescription(), () => new MultiplyOperationFlow()) },
        { "4", new MenuItem(Display: Operation.Division.GetDescription(), () => new DivisionOperationFlow()) },
        { "5", new MenuItem(Display: Operation.All.GetDescription(), () => new RandomOperationFlow()) },
        { "6", new MenuItem("Back", () => new MainMenuState()) },
    };

    public override void ProcessGameLoop()
    {
        MenuItem menuItem = (this as IMenu).ProcessMenu();
        Context.ChangeState(menuItem.Creator.Invoke());
    }

    public ReadOnlyDictionary<string, MenuItem> MenuItems => _menuItems.AsReadOnly();
}