namespace abdukulov_talgat.MathGame.UI;

public record MenuItem(string Display, Func<FlowStateBase> Creator);