using FluentValidation;
using HolloFabrika.Api.Contracts.Dto;
using HolloFabrika.Feature.Features.Categories;

namespace HolloFabrika.Api.Validators;

public class CategoryValidator : AbstractValidator<CategoryRequest>
{
    public CategoryValidator(GetCategoryFeature getCategoryFeature)
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Attributes)
            .NotNull();

        RuleForEach(x => x.Attributes)
            .SetValidator(new CategoryAttributeValidator());
    }
}

internal class CategoryAttributeValidator : AbstractValidator<CategoryAttributeRequest>
{
    public CategoryAttributeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty");
    }
}