namespace abdukulov_talgat.MathGame.UI;

public class ExitFlowState : FlowStateBase
{
    private const int SecondsBeforeExit = 3;

    public override void ProcessGameLoop()
    {
        for (int i = SecondsBeforeExit; i > 0; i--)
        {
            Console.WriteLine($"Exiting in {i}...");
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        Context.Exit();
    }
}