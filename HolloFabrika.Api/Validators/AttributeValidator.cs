using FluentValidation;
using HolloFabrika.Api.Contracts.Request;

namespace HolloFabrika.Api.Validators;

public class CreateAttributeValidator : AbstractValidator<CreateAttributeRequest>
{
    public CreateAttributeValidator()
    {
        RuleFor(x => x.CategoryId)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}

public class UpdateAttributeValidator : AbstractValidator<UpdateAttributeRequest>
{
    public UpdateAttributeValidator()
    {
        RuleFor(x => x.CategoryId)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}