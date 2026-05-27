namespace ClaimTheSquareAfter;

public class ClaimResult
{
    private ClaimResult(bool isSuccess, string? successMessage, string? errorMessage)
    {
        IsSuccess = isSuccess;
        SuccessMessage = successMessage;
        ErrorMessage = errorMessage;
    }

    public bool IsSuccess { get; }
    public string? SuccessMessage { get; }
    public string? ErrorMessage { get; }

    public static ClaimResult Success(string message)
    {
        return new ClaimResult(true, message, null);
    }

    public static ClaimResult Failure(string message)
    {
        return new ClaimResult(false, null, message);
    }
}
