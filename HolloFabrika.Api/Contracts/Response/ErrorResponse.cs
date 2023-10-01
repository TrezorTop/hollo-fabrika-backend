namespace HolloFabrika.Api.Contracts.Response;

public class ErrorResponse
{
    public string? Message { get; set; }
    public ValidationError[]? ValidationErrors { get; set; }
}

public class ValidationError
{
    public required string PropertyName { get; set; }
    public required string ErrorMessage { get; set; }
    public required object AttemptedValue { get; set; }
}