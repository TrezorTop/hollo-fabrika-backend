namespace HolloFabrika.Api.Contracts.Dto;

public class CategoryRequest
{
    public string? Name { get; set; }
    public ICollection<CategoryAttributeRequest>? Attributes { get; set; }
}

public class CategoryAttributeRequest
{
    public string? Name { get; set; }
}

public class CategoryResponse
{
    public required Guid Id { get; set; } = Guid.NewGuid();
    public required string? Name { get; set; }
    public required ICollection<CategoryAttributeResponse> Attributes { get; set; }
}

public class CategoryAttributeResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}