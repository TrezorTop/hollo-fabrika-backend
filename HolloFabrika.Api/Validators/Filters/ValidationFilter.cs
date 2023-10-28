using FluentValidation;
using HolloFabrika.Api.Extensions;

namespace HolloFabrika.Api.Validators.Filters;

public class ValidationFilter<T> : IEndpointFilter
{
    private readonly IValidator<T> _validator;

    public ValidationFilter(IValidator<T> validator)
    {
        _validator = validator;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var argToValidate = context.Arguments.SingleOrDefault(t => t?.GetType() == typeof(T));

        if (argToValidate == null) return Results.StatusCode(StatusCodes.Status500InternalServerError);

        var result = await _validator.ValidateAsync((T)argToValidate);
        
        if (!result.IsValid) return Results.BadRequest(result.ToErrorResponse());

        return await next(context);
    }
}