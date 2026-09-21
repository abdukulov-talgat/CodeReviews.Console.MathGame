using abdukulov_talgat.MathGame.Core;

namespace abdukulov_talgat.MathGame.UI;

public class PlusOperationFlow : OperationFlowStateBase
{
    public override Operation GetRelevantOperation() => Operation.Plus;
}

public class MinusOperationFlow : OperationFlowStateBase
{
    public override Operation GetRelevantOperation() => Operation.Minus;
}

public class MultiplyOperationFlow : OperationFlowStateBase
{
    public override Operation GetRelevantOperation() => Operation.Multiply;
}

public class DivisionOperationFlow : OperationFlowStateBase
{
    public override Operation GetRelevantOperation() => Operation.Division;
}

public class RandomOperationFlow : OperationFlowStateBase
{
    public override Operation GetRelevantOperation() => Operation.All;
}