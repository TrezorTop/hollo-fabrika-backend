using FluentValidation;
using HolloFabrika.Api.Contracts.Request;

namespace HolloFabrika.Api.Validators;

public class CategoryValidator : AbstractValidator<CreateCategoryRequest>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Attributes)
            .NotNull();

        RuleForEach(x => x.Attributes)
            .SetValidator(new CreateCategoryAttributeValidator());
    }
}

internal class CreateCategoryAttributeValidator : AbstractValidator<CreateCategoryAttributeRequest>
{
    public CreateCategoryAttributeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty");
    }
}

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Attributes)
            .NotNull();

        RuleForEach(x => x.Attributes)
            .SetValidator(new UpdateCategoryAttributeValidator());
    }
}

internal class UpdateCategoryAttributeValidator : AbstractValidator<UpdateCategoryAttributeRequest>
{
    public UpdateCategoryAttributeValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty();
    }
}