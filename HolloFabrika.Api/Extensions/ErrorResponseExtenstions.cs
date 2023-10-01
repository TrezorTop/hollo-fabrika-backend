using FluentResults;
using FluentValidation.Results;
using HolloFabrika.Api.Contracts.Response;

namespace HolloFabrika.Api.Extensions;

public static class ErrorResponseExtenstions
{
    public static ErrorResponse ToErrorResponse(this ValidationResult validationResult)
    {
        return new ErrorResponse
        {
            Message = "Validation Error",
            ValidationErrors = validationResult.Errors.Select(x => new ValidationError
            {
                ErrorMessage = x.ErrorMessage,
                AttemptedValue = x.AttemptedValue,
                PropertyName = x.PropertyName
            }).ToArray()
        };
    }

    public static ErrorResponse ToErrorResponse<T>(this Result<T> result)
    {
        return new ErrorResponse
        {
            Message = result.Reasons.First().Message,
            ValidationErrors = null
        };
    }
}