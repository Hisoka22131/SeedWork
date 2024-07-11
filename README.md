# Notifications (design validations in the domain model layer)

```csharp

public class Manager
{
    public string Email { get; private set; }
    public string Password { get; private set; }

    private Manager(){ }
    
    public OperationResult<Manager> Create(string email, string password)
    {
        var validateResult = Validate(email, password);
        if (!validateResult.Ok) return validateResult;
        
        Email = email;
        Password = password;
        
        return new OperationResult<Manager>
        {
            Result = this
        };
    }
    
    private static EmptyOperationResult Validate(string email, string password)
    {
        var result = new EmptyOperationResult();
        
        if (!string.IsNullOrWhiteSpace(email))
            result.AddError(Errors.Manager.ManagerEmailIsInvalid);
        
        if (!string.IsNullOrWhiteSpace(password))
            result.AddError(Errors.Manager.ManagerPasswordIsInvalid);

        return result;
    }
}

public static partial class Errors
{
    public static class Manager
    {
        public static OperationError ManagerEmailIsInvalid => new OperationError(
            errorCode: "Manager.ManagerEmailIsInvalid",
            errorMessage: "Manager email is invalid");
        
        public static OperationError ManagerPasswordIsInvalid => new OperationError(
            errorCode: "Manager.ManagerPasswordIsInvalid",
            errorMessage: "Manager password is invalid");
    }
}

```