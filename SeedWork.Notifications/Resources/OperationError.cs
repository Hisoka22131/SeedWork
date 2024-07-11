namespace SeedWork.Notifications.Resources;

public class OperationError
{
    private readonly string _errorCode;
    private readonly string _errorMessage;

    public OperationError(string errorCode, string errorMessage)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(errorCode);
        ArgumentException.ThrowIfNullOrWhiteSpace(errorMessage);
        
        _errorCode = errorCode;
        _errorMessage = errorMessage;
    }
}