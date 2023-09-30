namespace HolloFabrika.Api.Contracts.Request;

public class CreateCategoryRequest
{
    public required string Name { get; set; }
    public required ICollection<CreateCategoryAttributeRequest> Attributes { get; set; }
}

public class CreateCategoryAttributeRequest
{
    public required string Name { get; set; }
}

public class UpdateCategoryRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<UpdateCategoryAttributeRequest> Attributes { get; set; }
}

public class UpdateCategoryAttributeRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}