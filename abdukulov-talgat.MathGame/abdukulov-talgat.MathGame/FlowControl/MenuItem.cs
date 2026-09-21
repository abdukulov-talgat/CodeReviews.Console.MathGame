namespace abdukulov_talgat.MathGame.FlowControl;

public record MenuItem(string Display, Func<FlowStateBase> Creator);