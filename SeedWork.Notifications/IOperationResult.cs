using SeedWork.Notifications.Resources;

namespace SeedWork.Notifications;

public interface IOperationResult
{
    IReadOnlyCollection<OperationError>? Errors { get; }
    bool Ok { get; }
}

public interface IOperationResult<out TResult> : IOperationResult
{
    TResult? Result { get; }
}