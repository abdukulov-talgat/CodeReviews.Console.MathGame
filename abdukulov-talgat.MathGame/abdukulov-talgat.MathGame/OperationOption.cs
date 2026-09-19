using abdukulov_talgat.MathGame.Core;
using abdukulov_talgat.MathGame.Helpers;

namespace abdukulov_talgat.MathGame;

public record OperationOption(string Key, string Display, Operation Value)
{
    public static readonly OperationOption Plus = new OperationOption("1", "+", Operation.Plus);

    public static readonly OperationOption Minus = new OperationOption("2", "-", Operation.Minus);

    public static readonly OperationOption Multiply = new OperationOption("3", "*", Operation.Multiply);

    public static readonly OperationOption Division = new OperationOption("4", "/", Operation.Division);

    public static readonly OperationOption Mix = new OperationOption("5", "Mix",
        Operation.Plus | Operation.Minus | Operation.Multiply | Operation.Division);

    public static readonly IReadOnlyCollection<OperationOption> All = [Plus, Minus, Multiply, Division, Mix];

    public static Result<OperationOption> TryParse(string? key)
    {
        OperationOption? result = All.FirstOrDefault(o => o.Key == key);

        return result is not null
            ? Result<OperationOption>.Success(result)
            : Result<OperationOption>.Failure($"Wrong key. key: {key}");
    }
}