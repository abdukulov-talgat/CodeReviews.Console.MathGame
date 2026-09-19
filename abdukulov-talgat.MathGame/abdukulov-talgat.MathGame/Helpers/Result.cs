namespace abdukulov_talgat.MathGame.Helpers;

public record Result<T> where T : class?
{
    public T? Value { get; init; }

    public string? Message { get; init; }

    public bool IsSuccess { get; init; }

    public bool IsFailure => !IsSuccess;

    private Result(T? value, string? message, bool isSuccess)
    {
        Value = value;
        Message = message;
        IsSuccess = isSuccess;
    }

    public static Result<T> Success(T value) => new Result<T>(value, null, true);

    public static Result<T> Failure(string? message) => new Result<T>(null, message, false);
}