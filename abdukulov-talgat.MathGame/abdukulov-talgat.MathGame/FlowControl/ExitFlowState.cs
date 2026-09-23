namespace abdukulov_talgat.MathGame.FlowControl;

public class ExitFlowState : FlowStateBase
{
    public override void ProcessGameLoop()
    {
        for (int i = AppConsts.SecondsBeforeExit; i > 0; i--)
        {
            Console.WriteLine($"Exiting in {i}...");
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        Context.Exit();
    }
}