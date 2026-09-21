namespace abdukulov_talgat.MathGame.FlowControl;

public abstract class FlowStateBase
{
    protected GameFlowContext Context = null!;

    public abstract void ProcessGameLoop();

    public void SetContext(GameFlowContext context)
    {
        Context = context;
    }
    
}